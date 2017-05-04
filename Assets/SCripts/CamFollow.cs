using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    private Vector3 velocity;
    public float smoothtimeX, smoothtimeY, smoothtimeZ;
    public GameObject player;
    public bool bounds;
    public Vector3 minCamPos;
    public Vector3 maxCamPos;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("PlayerPos");
	}
	
	void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);
        float posZ = Mathf.SmoothDamp(transform.position.z, player.transform.position.z, ref velocity.x, smoothtimeZ);
        transform.position = new Vector3(posX, posY, posZ);
        if(bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x), Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y), Mathf.Clamp(transform.position.z, minCamPos.z, maxCamPos.z));
        }
	}

}
