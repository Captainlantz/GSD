using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<GameManager>().GameOver();
        }
        else if (other.CompareTag("Enemy"))
        {
            FindFirstObjectByType<GameManager>().EnemyDefeated();
            //Destroy(other.gameObject);
        }
    }
}
