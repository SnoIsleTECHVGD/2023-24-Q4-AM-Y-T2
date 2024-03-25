using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetCode : MonoBehaviour
{

    
    public float timer;
    public float deathtimer;


    private void Start()
    {
        deathtimer = 20.0f;
        GetComponent<SpriteRenderer>().enabled = false;

    }
    //if the enemy finds the target it stops in place and appears
    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<NavMeshAgent>().speed = 0;
            
        }



    }
    //Makes timer stay at 50 and starts counter for if you die
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            timer = 50.0f;
            deathtimer -= Time.deltaTime;
        }


    }

    //If player leaves then the creature dissapears from sight and starts the countdown. Also resets death counter.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer -= Time.deltaTime;
            GetComponent<NavMeshAgent>().speed = 3.5f;
            GetComponent<SpriteRenderer>().enabled = false;
            deathtimer = 20.0f;
        }


    }

   //Countdown dictates how long creature chases the player. if countdown is 0, player dies.

    private void Update()
    {
        timer -= Time.deltaTime;
        

        if(timer > 0.0f)
        {
            GetComponent<UnityPatrol>().enabled = false;
           GetComponent<Followplayer>().enabled = true;


        }
        else
        {
            GetComponent<UnityPatrol>().enabled = true;
            GetComponent<Followplayer>().enabled = false;
            timer = 0.0f;


        }


        if(deathtimer <= 0.0f)
        {
            Debug.Log("You are dead");


        }


    }



}
