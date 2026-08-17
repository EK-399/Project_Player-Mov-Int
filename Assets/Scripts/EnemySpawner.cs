using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool spawnEnemies;


    // Spawn an enemy
    public GameObject enmeyPrefab;

    // Delay amd then do it again
    public float spawnInterval;

    // Max amout of enemies to spawn
    public int maxEnemyAmount;
    public int currntEnemyAmount;

    void Start()
    {
        StartCoroutine(SpwnEnemy()); //Start

        //Invoke("SpawnEnemyFunction", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SpwnEnemy()
    {
        while (spawnEnemies == true)
        {
            float x = Random.Range(-8, 8);
            float y = Random.Range(-4, 4);
            Vector3 randomSpawnPosition = new Vector3(x, y, 0);

            //SPAWN!
            Instantiate(enemyPrefab, randomSpawnPosition) Quaternion.identity;
            currentEnemyAmout++;

            if (currentEnemyAmount >= maxEnemyAmount)
            {

            }
            
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    //void SpawnEnemyFunction()
    //{
    //    Debug.Log("Spawn Enemies with Invoke");
    //}
}

