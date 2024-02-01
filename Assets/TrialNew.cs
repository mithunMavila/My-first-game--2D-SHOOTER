using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialNew : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float DirX = Input.GetAxis("Horizontal");
        transform.Translate(DirX*Time.deltaTime*speed,0,0);

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag== "trap") { Destroy(collision.gameObject); }
        
    }
}
