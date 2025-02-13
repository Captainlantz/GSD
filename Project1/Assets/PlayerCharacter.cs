using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private bool playerAlive;

    private int health;
    void Start()
    {
        health = 25;
        playerAlive = true;
    }
    public void Hurt(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            FPSInput mover = GetComponent<FPSInput>();
            mover.setAlive(false);
            SetPlayerAlive(false);
            Debug.Log($"Player Has Died");
        }
        Debug.Log($"Player Health : {health}");
    }
    public void Heal(int add)
    {
        health += add;
        Debug.Log($"Player Health : {health}");
    }
    public void SetPlayerAlive(bool isAlive)
    {
        this.playerAlive = isAlive;
    }
    public bool getPlayerAlive()
    {
        return this.playerAlive;
    }
}
