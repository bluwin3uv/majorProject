using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 20f;
    public Transform[] movePoint;
    private int Curpoint = 0;
    private Rigidbody rb;
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        Move();
	}

    void Move()
    {
        if (transform.position == movePoint[Curpoint].position)
        {
            Curpoint++;
        }
        if(Curpoint >= movePoint.Length)
        {
            Curpoint = 0; 
        }
    }
}
