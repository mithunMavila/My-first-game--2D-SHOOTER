using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public float movementSpeed = 5f;
    public float maxDistanceFromInitial = 5f;

    private Rigidbody2D rb;
    private Vector3 initialPosition;
    public float distanceToInitial;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float shootInterval = 4f;
   public int life= 20;
    private float bulletSpeed = 8f;

   public float timeSinceLastShot;
    private float angleToPlayer;
    public float ShDistance = 10f;
    public float bulletLife = 2f;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;   
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(life);
    }

    // Update is called once per frame
    void Update()
    {
        distance= Vector2.Distance(player.transform.position,transform.position);
        distanceToInitial = Vector2.Distance(transform.position, initialPosition);
        if (distance < ShDistance)
        {
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
            float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angleToPlayer, 0f);

            timeSinceLastShot += Time.deltaTime;

            if (timeSinceLastShot >= shootInterval)
            {
                timeSinceLastShot = 0f;
                Shoot();
            }
        }
        if (distance<ShDistance && distance >3f && distanceToInitial < maxDistanceFromInitial)
        {
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
            rb.velocity = directionToPlayer * movementSpeed;
            angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angleToPlayer, 0f);
           
        }
        else if(distance < 3f)
        {
            rb.velocity = Vector2.zero;
        }
    }
    void Shoot()
    {
        
        
        
        // Instantiate a bullet at the shooting point position and with the calculated rotation
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(0f, angleToPlayer, 0f));
        
        // Rotate the bullet to face the shooting direction
       
        // Add force to the bullet to make it move forward
        bullet.GetComponent<Rigidbody2D>().AddForce(shootingPoint.right * bulletSpeed, ForceMode2D.Impulse);
        Destroy(bullet, bulletLife);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            life = life - 10;
            healthBar.SetHealth(life);
            if (life <= 0)
            {
                death();
            }
            Destroy(collision.gameObject);
        }
    }
    private void death()
    {
        Destroy(gameObject);
    }


}
