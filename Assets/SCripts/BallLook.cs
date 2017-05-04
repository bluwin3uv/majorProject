using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLook : MonoBehaviour
{
    public bool boundds;
    public Quaternion minTheta;
    public Quaternion maxTheta;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {
        if(boundds)
        {
            transform.rotation = Quaternion.Euler(Mathf.Clamp(transform.rotation.x, minTheta.x, maxTheta.x), Mathf.Clamp(transform.rotation.y, minTheta.y, maxTheta.y), Mathf.Clamp(transform.rotation.z, minTheta.z, maxTheta.z));
        }
    }
}
