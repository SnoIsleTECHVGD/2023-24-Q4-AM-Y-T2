using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


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
    //bool Spotted;
    public float Xplayer;
    public float Xcreature;
    public float Xcoord;
    public float Ycoord;
    private Animator creatureanim;
    public GameObject playercam;
    public float chasespeed = 8.0f;
    public float patrolspeed = 3.5f;
    public float waittime;
    public GameObject win;
    public GameObject lose;

    private void Start()
    {
        deathtimer = 6.0f;
        GetComponent<SpriteRenderer>().enabled = false;
        IsDead = false;
        creatureanim = GetComponent<Animator>();

        Xplayer = playercam.transform.position.x;
        Xcreature = transform.position.x;

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
            //Spotted = true;
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
            //Spotted = false;
            GetComponent<NavMeshAgent>().speed = chasespeed;
            GetComponent<NavMeshAgent>().acceleration = 99999999f;
            GetComponent<SpriteRenderer>().enabled = false;
           
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
            GetComponent<NavMeshAgent>().speed = patrolspeed;
            GetComponent<NavMeshAgent>().acceleration = 8.0f;
            GetComponent<UnityPatrol>().enabled = true;
            GetComponent<Followplayer>().enabled = false;
            timer = 0.0f;
            Invoke(nameof(DeathRecover), 0.3f);

        }

       


        if(deathtimer <= 0.0f)
        {
            Debug.Log("You are dead");
            IsDead = true;
            creatureanim.enabled = true;
            Invoke(nameof(DeathState), 0.0f);
        }

        if(deathtimer >= 6.0f)
        {

            deathtimer = 6.0f;

        }

        if(WinTimer <= 0.0f || Input.GetKeyDown(KeyCode.W))
        {

            Debug.Log("You Win!");
            YouWon = true;
            playercam.transform.position = new Vector3(win.transform.position.x, win.transform.position.y, -100);


        }

        if(Xplayer > Xcreature)
        {

            GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {

            GetComponent<SpriteRenderer>().flipX = false;

        }

        if (IsDead)
        {
            WinTimer = 1.0f;


        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainScene");


        }

       

    }

    void DeathRecover()
    {
        deathtimer += Time.deltaTime;



    }

    void DeathState()
    {
        
        Xcoord = playercam.transform.position.x;
        Ycoord = playercam.transform.position.y;


        transform.position = new Vector3(Xcoord, Ycoord, -99.0f);
        Invoke(nameof(TimeOutCorner), waittime);

    }

    void TimeOutCorner()
    {

        playercam.transform.position = new Vector3(lose.transform.position.x, lose.transform.position.y, -100);


    }


}
