using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed;
    public float rotationSpeed = 10f;



    void Start()
    {

    }



    void Update()
    {
        //bool isKnife = knife.isKnife;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        }


        float aimDirectionX = Input.GetAxisRaw("Horizontal");
        float aimDirectionY = Input.GetAxisRaw("Vertical");
        if (aimDirectionX != 0f || aimDirectionY != 0f)
        {

            float targetAngle = Mathf.Atan2(aimDirectionY, aimDirectionX) * Mathf.Rad2Deg;


            Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

    }

    void Shoot()
    {
        // Instantiate a bullet at the shooting point position and rotation
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        // Add force to the bullet to make it move forward
        bullet.GetComponent<Rigidbody2D>().AddForce(shootingPoint.right * bulletSpeed, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
    }
   

}
