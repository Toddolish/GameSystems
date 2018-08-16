using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //declaration
    public enum State
    {
        Patrol, Seek
    }

    public State currentState = State.Patrol;
    public Transform Player;
    public Transform waypointParent;
    public float seekRadius = 5f;

    //create a collection of transforms.
    public Transform[] waypoints;
    private int currentIndex = 0;
    public float range;
    public float moveSpeed;


    //ctrl + k + d
    //camelCasing - variables
    //PascalCasing - function and class names

    public NavMeshAgent agent;
    //public Transform target;
    private void Start()
    {
        //getting children of waypoint parent.
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
    }

    //////////////////update
    void Update()
    {
        //switch current state
        //if we are in patrol
        //call patrol()
        //if me are in seek
        //call seek()
        switch (currentState)
        {
            case State.Patrol:
                //patrol state
                Patrol();
                break;

            case State.Seek:
                //seek state
                Seek();
                break;

            default:
                break;
        }
        
    }
    void Patrol()
    {
        //move towards waypoints
        Transform point = waypoints[currentIndex];
        float distance = Vector3.Distance(agent.transform.position, point.position);

        if (distance < range)
        {
            currentIndex++;
        }
        if (currentIndex >= waypoints.Length)
        {
            currentIndex = 0;
        }
        float disToTarget = Vector3.Distance(transform.position, Player.position);
        if(disToTarget < seekRadius)
        {
            currentState = State.Seek;
        }
        agent.SetDestination(point.position);
        // transform.position = Vector3.MoveTowards(transform.position, point.position, 0.1f);
    }
    void Seek()
    {
        //move towards player
        float distance = Vector3.Distance(agent.transform.position, Player.position);

        if (distance < range)
        {
            currentIndex++;
        }
        if (currentIndex >= waypoints.Length)
        {
            currentIndex = 0;
        }
        float disToTarget = Vector3.Distance(transform.position, Player.position);
        if (disToTarget > seekRadius)
        {
            currentState = State.Patrol;
        }
        agent.SetDestination(Player.position);
    }
}
