using TMPro;
using UnityEngine;
using Mirror;

public class PlayerNameDisplay : NetworkBehaviour
{
    public TextMeshPro textMesh;

    void Update()
    {
        if (textMesh != null)
        {
            PlayerData data = GetComponent<PlayerData>();
            textMesh.text = $"{data.playerName}\nHP: {data.hp}";
        }
    }
}
