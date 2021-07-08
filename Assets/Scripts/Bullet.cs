using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] int health = 5;
    public bool powerShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.right * Time.deltaTime * speed;
        Destroy(gameObject, 3);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<Enemy>().TakeDamage();

            if (!powerShot) {
                Destroy(gameObject);
            } else {
                health--;
            }

            if (health <= 0) {
                Destroy(gameObject);
            }
            
        }
    }
       
}
