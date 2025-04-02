using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coinCount = 0;
    public TextMeshProUGUI coinText;

    public GameObject goldenPlatform; 

    void Update()
    {
        if (coinCount >= 10 && !goldenPlatform.activeSelf)
        {
            goldenPlatform.SetActive(true);
        }
    }
    private void Awake()
    {
        instance = this;
    }

    public void AddCoin()
    {
        coinCount++;
        coinText.text = "Coins: " + coinCount;
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
   

}

