using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 1;
    Transform player;
    [SerializeField] float speed = 1f;
    [SerializeField] int scorePoints = 100;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int randomSpawnPoint = Random.Range(0, spawnPoint.Length);
        transform.position = spawnPoint[randomSpawnPoint].transform.position;
    }   

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        transform.position += (Vector3)direction * Time.deltaTime * speed;
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0) {
            health = 0;
            GameManager.Instance.Score += scorePoints;
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent< Player>().TakeDamage();
            
        }


    }

    

    
}
