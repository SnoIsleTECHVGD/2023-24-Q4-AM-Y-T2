using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetCode : MonoBehaviour
{

    public GameObject Creature;
    public float timer;
    public float deathtimer;


    private void Start()
    {
        deathtimer = 20.0f;
        Creature.GetComponent<SpriteRenderer>().enabled = false;

    }
    //if the enemy finds the target it stops in place and appears
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Creature"))
        {
            Creature.GetComponent<SpriteRenderer>().enabled = true;
            Creature.GetComponent<NavMeshAgent>().speed = 0;
            
        }



    }
    //Makes timer stay at 50 and starts counter for if you die
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Creature"))
        {
            timer = 50.0f;
            deathtimer -= Time.deltaTime;
        }


    }

    //If player leaves then the creature dissapears from sight and starts the countdown. Also resets death counter.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Creature"))
        {
            timer -= Time.deltaTime;
            Creature.GetComponent<SpriteRenderer>().enabled = false;
            deathtimer = 20.0f;
        }


    }

   //Countdown dictates how long creature chases the player. if countdown is 0, player dies.

    private void Update()
    {
        timer -= Time.deltaTime;
        

        if(timer > 0.0f)
        {
            Creature.GetComponent<UnityPatrol>().enabled = false;
            Creature.GetComponent<Followplayer>().enabled = true;


        }
        else
        {
            Creature.GetComponent<UnityPatrol>().enabled = true;
            Creature.GetComponent<Followplayer>().enabled = false;
            timer = 0.0f;


        }


        if(deathtimer <= 0.0f)
        {
            Debug.Log("You are dead");


        }


    }



}
