using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    private GameObject enemy;

    private int wave;

    private bool waitingForNextWave = false;
    
    public static int enemycount;
    
    void Start()
    {
        wave = 1;
        startWave(wave);
    }
    void Update() 
    {
        
        if (enemycount == 0 && !waitingForNextWave) 
        {
            StartCoroutine(nextWave());
        }
    }//end update

    private void startWave(int wave)
    {
        switch (wave)
        {
            case 1:
                makeEnemy(1, 1);
                break;
            case 2:
                makeEnemy(2, 2);
                break;
            case 3:
                makeEnemy(3, 3);
                break;

        }
    }


    /*private void nextWave()
    {
        if (wave < 4)
        {
            wave++;
            startWave(wave);
        }
        else
        {
            //WIN CONDITION
        }
    }*/

    private IEnumerator nextWave()
    {
        waitingForNextWave = true;
        yield return new WaitForSeconds(4.0f);

        if (wave < 4)
        {
            wave++;
            startWave(wave);
        }
        else
        {
            Debug.Log("You Win!");
        }

        waitingForNextWave = false;
    }

    private void makeEnemy(int number, int health)
    {
        enemycount = number;
        for (int i = 0; i < number; i++)
        {
            
            Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), 1, Random.Range(-3f, 3f));

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            EnemyCharacter character = enemy.GetComponent<EnemyCharacter>();
            if (character != null)
            {
                character.setHealth(health);
            }

            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}
