using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sky : MonoBehaviour {
    public float rot;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Rotate(rot, 0, 0);
	}
}
