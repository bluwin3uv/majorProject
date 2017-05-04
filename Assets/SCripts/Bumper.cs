using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bumper : MonoBehaviour
{
    public float force;
    GameObject player;
    Rigidbody myRigi;
    void Start()
    {
        myRigi = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other) // Is called whenver rigidbody collides with something
    {
        if (other.transform.tag == "Player")
        {
            myRigi.AddForce((transform.position - other.contacts[0].point) * force);
            print(other.contacts[0].point);
        }
    }
}


