using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public ItemManager ItemManager;
    public TextMeshProUGUI coinCount;

    private void Update()
    {
        coinCount.text = ItemManager.coins.ToString();
    }
}
