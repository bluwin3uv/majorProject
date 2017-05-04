using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public float force;
    private Rigidbody rb;
    	
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Bounce")
        {
            rb.AddForce((transform.position - other.contacts[0].point) * force);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "BlackHole")
        {
            scenemanager.completelevel();
        }
    }


}
