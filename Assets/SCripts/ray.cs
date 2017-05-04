using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour {

    void Start()
    {

    }

	void FixedUpdate() 
    {
        Debug.DrawRay(transform.position,transform.forward);
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if(Physics.Raycast(transform.position,fwd,3))
        {
            
        }
	}
}
