using UnityEngine;
using TMPro;
using Mirror;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI hpText;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public void UpdateHP(int hp)
    {
        if (hpText != null)
            hpText.text = "HP: " + hp.ToString();
    }
}
