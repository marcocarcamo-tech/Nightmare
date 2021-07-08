using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hor;
    float ver;
    Vector3 movement;
    [SerializeField] float speed = 4;
    [SerializeField] Transform aim;
    [SerializeField] Camera cam;
    Vector2 facingDirection;
    [SerializeField] Transform bulletPrefab;
    bool isLoaded = true;
    [SerializeField] float fireRate = 1f;
    [SerializeField] int health = 5;
    bool powerShotEnabled;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        movement.x = hor;
        movement.y = ver;

        transform.position += movement * Time.deltaTime * speed;


        //Aim movement
        facingDirection = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;

        if (Input.GetMouseButtonDown(0) && isLoaded)
        {
            isLoaded = false;
            
            //angle between player and aim, math function in radians then transform degrees
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            //Create a new quaternion
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Transform bulletClone = Instantiate(bulletPrefab, transform.position, targetRotation);

            if (powerShotEnabled) {
                bulletClone.GetComponent<Bullet>().powerShot = true;
            }
            StartCoroutine(ReloadGun());
        }

        
    }

    IEnumerator ReloadGun() {
        yield return new WaitForSeconds(0.5f/fireRate);
        isLoaded = true;
    }

    public void TakeDamage()
    {
        health--;
        Debug.Log("Player's health is" + health);
        Die();
    }

    void Die() {
        if (health <= 0) {
            health = 0;
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp")) {
            switch (collision.GetComponent<PowerUp>().powerUpType) {
                case PowerUp.PowerUpType.FireRateIncrease:
                    //incrementar cadencia de tiro
                    fireRate++;
                    break;
                case PowerUp.PowerUpType.PowerShot:
                    //incrementar la fuerza de tiro
                    powerShotEnabled = true;
                    break;
            }

            Destroy(collision.gameObject, 0.1f);
        }
    }
}
