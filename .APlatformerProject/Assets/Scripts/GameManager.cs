using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI gameOverText;
    [SerializeField]
    public TextMeshProUGUI winText;
    [SerializeField]
    public GameObject boss; 
    public int enemyCount = 3; 

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        boss.SetActive(false); 
    }

    public void EnemyDefeated()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            boss.SetActive(true);
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void WinGame()
    {
        winText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}

