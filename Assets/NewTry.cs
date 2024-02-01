using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTry : MonoBehaviour
{
    public Rigidbody2D rg;
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
}
