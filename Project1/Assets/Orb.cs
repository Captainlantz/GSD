using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour
{
    [SerializeField]
    private int health = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Disappear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Heal(health);
        }


        Destroy(this.gameObject);
    }

    private IEnumerator Disappear()
    {

        yield return new WaitForSeconds(5.0f);


        Destroy(this.gameObject);
    }
}

