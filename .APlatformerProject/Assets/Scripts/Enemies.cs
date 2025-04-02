using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform leftPoint, rightPoint;
    private bool movingRight = true;
    private bool falling = false; 

   

    private void Update()
    {
        if(falling){
            transform.position += Vector3.down * 25f * Time.deltaTime;
        }
        else if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (transform.position.x >= rightPoint.position.x) movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if (transform.position.x <= leftPoint.position.x) movingRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (collision.contacts[0].normal.y < 0)
            {
                Die();
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            }
            else
            {
                
                FindFirstObjectByType<GameManager>().GameOver();
            }
        }
    }

    private void Die()
    {
        transform.RotateAround(transform.position, transform.right, 180f);
        falling = true;
    }
}
