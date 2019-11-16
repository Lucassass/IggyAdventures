using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    public Transform waypoint1;
    public Transform waypoint2;
    public float speed;
    int target = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform targetwaypoint;
        if (target == 1)
        {
            targetwaypoint = waypoint1;
            //Debug.Log("heading toward 1");
        }
        else
        {
            targetwaypoint = waypoint2;
           // Debug.Log("heading toward 2");
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetwaypoint.position, step);
        if (System.Math.Abs(transform.position.x - targetwaypoint.position.x) < 1)
        {

            Debug.Log("checkpoint reached");

            if (target == 1) { target++; }
            else { target--; }

        }

    }
}

