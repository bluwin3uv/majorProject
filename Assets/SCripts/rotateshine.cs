using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateshine : MonoBehaviour {

    public float rotSpeed = 0.01f;
    public float theta;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        theta += 1;
        transform.Rotate(0, rotSpeed, 0);
	}
}
