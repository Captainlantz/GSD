using UnityEngine;

public class Fireball : MonoBehaviour
{

    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private int damage = 1;

    void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
        }
        EnemyCharacter enemy = other.GetComponent<EnemyCharacter>();
        ReactiveTarget target = other.GetComponent<ReactiveTarget>();
        if (enemy != null)
        {
            enemy.Hurt(damage);
            target.ReactToHit();
        }

        Destroy(this.gameObject);
    }
}
