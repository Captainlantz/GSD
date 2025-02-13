using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    private int health;
    void Start()
    {

    }
    public void Hurt(int damage)
    {
        health -= damage;

        Debug.Log($"Enemy Health : {health}");
    }
    public int getHealth() { 
    return health;
    }
    public void setHealth(int set)
    {
        health = set;
    }
}
