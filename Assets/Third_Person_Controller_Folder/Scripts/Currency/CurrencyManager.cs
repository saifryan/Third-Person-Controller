using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinText;
    public static int TotalCoins = 0;

    private void Start()
    {
        TextUpdate();
    }

    // Coin Add
    public void AddCoins(int amount)
    {
        TotalCoins += amount;
        TextUpdate();
    }

    void TextUpdate()
    {
        CoinText.text = TotalCoins.ToString();
    }

    private void OnEnable()
    {
        // Coin Add
        DelegatesData.CoinAdd += AddCoins;
    }

    private void OnDisable()
    {
        // Coin Add
        DelegatesData.CoinAdd -= AddCoins;
    }
}