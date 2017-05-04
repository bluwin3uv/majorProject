using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Seeker))]
public class bot : MonoBehaviour
{
    [Header("Enemy AI")]
    // what to seek
    public Transform target;

    // Path update rate
    public float updateRate = 2f;


    private Seeker seeker;
    private Rigidbody rigi;


    // calculated path
    public Path path;

    // speed per second
    public ForceMode fMode;
    public float speed = 200f;

    [HideInInspector]
    public bool pathIsEnded = false;



    public float nextWayPointDistance = 3;


    // The waypoint we are currently moving towards
    private int currentWayPoint = 0;

    private bool searchingForPlayer = false;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        rigi = GetComponent<Rigidbody>();

        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }


            return;
        }


        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());

    }

    public void OnPathComplete(Path p)
    {
        // Debug.Log("we got a path. Did it have an error?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    IEnumerator SearchForPlayer()
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");

        if (sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        }
        else
        {
            searchingForPlayer = false;
            target = sResult.transform;
            StartCoroutine(UpdatePath());
            yield return false;
        }


    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            yield return false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }


    void FixedUpdate()
    {
        // Always look at player (homing projectiles)

        if (target == null)
        {
            return;
        }

        if (path == null)
        {
            return;
        }

        if (currentWayPoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            //  Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        // Dirrection to the next waypoint
        Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        // Movement for AI

        rigi.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);
        if (dist < nextWayPointDistance)
        {
            currentWayPoint++;
            return;
        }

    }

}
