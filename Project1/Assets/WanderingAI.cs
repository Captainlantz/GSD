using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WanderingAI : MonoBehaviour
{

    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private float obstacleRange = 5.0f;

    [SerializeField]
    private GameObject fireballPrefab;

    [SerializeField]
    private float cooldownTime = 1.0f;

    private bool onCooldown = false;

    private GameObject fireball;

    private bool isAlive;

    private PlayerCharacter player;


    private void Start()
    {
        isAlive = true;
        player = GameObject.Find("Capsule").GetComponent<PlayerCharacter>();
}

    public void SetAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }
    void Update()
    {
        if (isAlive && player.getPlayerAlive())
        {
           transform.Translate(0, 0, speed * Time.deltaTime);
        }
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, .75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (fireball == null && !onCooldown) 
                { 
                fireball = Instantiate(fireballPrefab) as GameObject;
                    onCooldown = true;
                    StartCoroutine(cooldownTimer());
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }
            }

            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    private IEnumerator cooldownTimer()
    {
        yield return new WaitForSeconds(cooldownTime);

        onCooldown = false;
    }
}
