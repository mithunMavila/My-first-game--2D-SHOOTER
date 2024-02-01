using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerDeath : MonoBehaviour
{
   // private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private int life=100;
    [SerializeField] private int count = 5;
    [SerializeField] private Transform initialPos;
    public HealthBar healthBar;
    public Text lifeCount;
    private void Start()
    {
       // anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(life);
        lifeCount.text=count.ToString();

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
            deathSound.Play();
        }
        if (collision.gameObject.tag == "enemyAttack")
        {
            life = life - 5;
            healthBar.SetHealth(life);
            if (life<=0)
            {
                Die();
            }
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "break")
        {
            Destroy(collision.gameObject,2f);
        }
    }
    private void Die()
    {
        //rb.bodyType = RigidbodyType2D.Static;
        // anim.SetTrigger("death");
        count--;
        lifeCount.text = count.ToString();
        transform.position = initialPos.position;
        if (count <= 0)
        {
            Restart();
        }
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
