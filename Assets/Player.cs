using UnityEngine;
using Mirror;

public class PlayerData : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnHPChanged))]
    public int hp = 100;

    [SyncVar]
    public string playerName = "Unknown";

    public override void OnStartLocalPlayer()
    {
        string randomName = "Player_" + Random.Range(1000, 9999);
        CmdSetPlayerName(randomName);
    }

    [Command]
    void CmdSetPlayerName(string name)
    {
        playerName = name;
    }

    void Start()
    {
        if (isLocalPlayer && UIManager.instance != null)
        {
            UIManager.instance.UpdateHP(hp);
        }
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.LogWarning("������� �������� HP �� �������!");
            hp = 9999; // ������������� �� ��������� � ������ �� ������
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdTakeDamage(10);
        }
    }

    void OnHPChanged(int oldHP, int newHP)
    {
        if (isLocalPlayer && UIManager.instance != null)
        {
            UIManager.instance.UpdateHP(newHP);
        }
    }

    [Command]
    void CmdTakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 0) hp = 0;
        Debug.Log("������ �������� HP: " + hp);
    }
}
