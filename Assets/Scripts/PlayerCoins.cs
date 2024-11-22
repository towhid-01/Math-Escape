using UnityEngine;
using TMPro;

public class PlayerCoins : MonoBehaviour
{
    public int currentCoins = 0;
    public TMP_Text coinText; // TextMesh Pro UI Text

    private void Start()
    {
        UpdateCoinUI(); // Update the coin UI at the start
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
