using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetCode : MonoBehaviour
{

    
    public float timer;
    public float deathtimer;
    public bool IsDead;
    public float WinTimer;
    public bool EasyMode;
    public bool MediumMode;
    public bool HardMode;
    public bool YouWon;

    public float Xcoord;
    public float Ycoord;
    private Animator creatureanim;
    public GameObject playercam;


    private void Start()
    {
        deathtimer = 20.0f;
        GetComponent<SpriteRenderer>().enabled = false;
        IsDead = false;
        creatureanim = GetComponent<Animator>();


        if (EasyMode)
        {
            MediumMode = false;
            HardMode = false;

            WinTimer = 100.0f;

        }

        if (MediumMode)
        {
            EasyMode = false;
            HardMode = false;

            WinTimer = 200.0f;

        }
        if (HardMode)
        {
            MediumMode = false;
            EasyMode = false;
            WinTimer = 300.0f;


        }
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

        WinTimer -= Time.deltaTime;


        if (timer > 0.0f)
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
            IsDead = true;
            WinTimer = 1.0f;
            Invoke(nameof(DeathState), 0.000001f);
        }

        if(WinTimer <= 0.0f)
        {

            Debug.Log("You Win!");
            YouWon = true;
            creatureanim.enabled = true;
            

        }




    }


    void DeathState()
    {
        
        Xcoord = playercam.transform.position.x;
        Ycoord = playercam.transform.position.y;


        transform.position = new Vector3(Xcoord, Ycoord, -99.0f);



    }


}
