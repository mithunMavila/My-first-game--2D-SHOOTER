using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bgloop : MonoBehaviour
{
   

    [SerializeField] private Transform camara;
    public Transform firstbg;
    public Transform secondbg;
    public float length = 35.38f;

    // Update is called once per frame
    void Update()
    {
        if (camara.position.x > firstbg.position.x)
        {
            secondbg.position = firstbg.position + Vector3.right * length;
        }
        if (camara.position.x < firstbg.position.x)
        {
            secondbg.position = firstbg.position + Vector3.left * length;
        }
        if(camara.position.x<secondbg.position.x || camara.position.x > secondbg.position.x)
        {
            Transform temp = firstbg;
            firstbg = secondbg;
            secondbg = temp;
        }
    }
}
