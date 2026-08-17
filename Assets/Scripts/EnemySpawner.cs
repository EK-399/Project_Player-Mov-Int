using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool spawnEnemies = true;

    // Spawn an enemy
    public GameObject enmeyPrefab;

    // Delay amd then do it again
    public float spawnInterval;

    // Max amout of enemies to spawn
    public int maxEnemyAmount;
    public int currentEnemyAmount;

    private void Start()
    {
        StartCoroutine(SpwnEnemy()); //Start

        //Invoke("SpawnEnemyFunction", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemyAmount <= 0 && !spawnEnemies)
        {
            spawnEnemies = true;
            StartCoroutine(SpwnEnemy());
        }
    }
    
    IEnumerator SpwnEnemy()
    {
        while (spawnEnemies == true)
        {
            float randomX = Random.Range(-8, 8);
            float randomY = Random.Range(-4, 4);
            Vector3 randomSpawnPosition = new Vector3(randomX, randomY, 0);

            //SPAWN!
            Instantiate(enmeyPrefab, randomSpawnPosition, Quaternion.identity);
            currentEnemyAmount += 1;

            if (currentEnemyAmount >= maxEnemyAmount)
                spawnEnemies = false;
            
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    //void SpawnEnemyFunction()
    //{
    //    Debug.Log("Spawn Enemies with Invoke");
    //}
}

