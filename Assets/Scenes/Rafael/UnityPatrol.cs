using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnityPatrol : MonoBehaviour
{


    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        //If autobraking is disabled, the agent will not slow down if it approaches a destination point
        agent.autoBraking = false;
        
        GoToNextPoint();

    }

    void GoToNextPoint()
    {

        //if no pints are set up, the code doesnt do anything
        if (points.Length == 0)
            return;

        // Make sure the agent goes to the right destinations
        agent.destination = points[destPoint].position;


        //chose next point, which can cycle back to the start
        //destPoint = (destPoint + 1) % points.Length;
        destPoint = (Random.Range(0,4)) % points.Length;


    }

    // Update is called once per frame
    void Update()
    {
        //when the agent gets close to the destination they are destined for, choose the next place they should go
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();
    }
}
