using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPoint : MonoBehaviour
{
    private Vector3 velo;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {

        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velo.x, 0);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velo.y, 0);
        float posZ = Mathf.SmoothDamp(transform.position.z, player.transform.position.z, ref velo.z, 0);
        transform.position = new Vector3(posX, posY, posZ);
    }
}
