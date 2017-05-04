using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperAnim : MonoBehaviour {

    private Animator anim;

	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	

	void OnTriggerEnter(Collider col)
    {
		if(col.CompareTag("Player"))
        {
            anim.SetTrigger("isHit");
        }
	}
}
