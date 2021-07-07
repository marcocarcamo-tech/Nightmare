using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]GameObject checkpointPrefab;
    [SerializeField] int checkpointSpawnDelay = 15;
    [SerializeField]float spawnRadius = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckpointRoutine());
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
}
