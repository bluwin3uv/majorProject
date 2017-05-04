using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    // Script for car, or variation of spiketrap. Moves between the points and hurst the player on cotact

    public float movementSpeed = 20f;
    public Transform[] patrolPoints;

    private GameObject player;
    private Vector3 startPosition;
    private Vector3 target;
    private int pLayerMask;
    private int currentPoint = 0;


    void Start()
    {
        startPosition = gameObject.transform.position;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Movement();
    }


    void Movement()
    {
        Vector3 movePos = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, movementSpeed * Time.deltaTime);
        transform.position = movePos;

        // Check if we have reached our waypoint, increment current point by 1

        if (transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
        }


        // Chekc if currentPoint i soutside range of array, Reset currentPoint to 0

        if (currentPoint >= patrolPoints.Length)
        {
            currentPoint = 0;
        }

    }


    void OnTriggerEnter(Collider col)
    {
       

        if(col.gameObject.tag == "Player")
        {
            player.SetActive(false);
        }
    }

}

