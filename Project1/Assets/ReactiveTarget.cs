using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject orbPrefab;

    private GameObject orb;
    public void ReactToHit()
    {
        EnemyCharacter enemy = gameObject.GetComponent<EnemyCharacter>();
        WanderingAI wander = gameObject.GetComponent<WanderingAI>();

        if(enemy.getHealth() == 0)
        {
            
            StartCoroutine(Die());
            wander.SetAlive(false);
        }
    }

    private IEnumerator Die()
    {
        SceneController.enemycount--;
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        orb = Instantiate(orbPrefab) as GameObject;
        orb.transform.position = transform.TransformPoint(Vector3.forward * 1.0f);
        orb.transform.rotation = transform.rotation;
        Destroy(this.gameObject);
    }
}
