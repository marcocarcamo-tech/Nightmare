using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //Checkpoint variables
    [SerializeField]GameObject checkpointPrefab;
    [SerializeField] int checkpointSpawnDelay = 15;
    [SerializeField]float spawnRadius = 10;

    //PowerUp variables
    [SerializeField] GameObject[] powerUpPrefab;
    [SerializeField] int powerUpSpawnDelay = 15;


    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckpointRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCheckpointRoutine() {

        while(true) {

            yield return new WaitForSeconds(checkpointSpawnDelay);

            //Creates a random instance area
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

            //Instantiate prefab
            Instantiate(checkpointPrefab, randomPosition, Quaternion.identity);
        }
        
    }

    IEnumerator SpawnPowerUpRoutine()
    {

        while (true)
        {

            yield return new WaitForSeconds(powerUpSpawnDelay);

            //Creates a random instance area
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

            int random = Random.Range(0, powerUpPrefab.Length);

            //Instantiate prefab
            Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);
        }

    }

}
