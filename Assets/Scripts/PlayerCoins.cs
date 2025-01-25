using UnityEngine;
using TMPro;

public class PlayerCoins : MonoBehaviour
{
    public int currentCoins = 0;
    public TMP_Text coinText;

    private void Start()
    {
        UpdateCoinUI(); 
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        coinText.text = "Coins: " + currentCoins.ToString();
    }
}
