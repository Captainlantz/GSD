using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField]
    public Transform leftPoint, rightPoint;
    public Transform moveAfterHitPosition; 
    public ParticleSystem hitEffect; 

    private bool movingRight = true;
    private int hitCount = 0;
    public float directionChangeChance = 2f;

    private void Update()
    {
        if (Random.Range(0, 1000) < 1) 
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
        if (Random.Range(0f, 100f) < directionChangeChance)
        {
            movingRight = !movingRight; 
        }
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= rightPoint.position.x) movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= leftPoint.position.x) movingRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.contacts[0].normal.y < 0) 
            {
                HitReaction();
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            }
            else
            {
                FindFirstObjectByType<GameManager>().GameOver(); 
            }
        }
    }

    private void HitReaction()
    {
        hitCount++;

        
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if (hitCount < 3) 
        {
            transform.position = moveAfterHitPosition.position;
        }
        else 
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        FindFirstObjectByType<GameManager>().WinGame();
    }
}
