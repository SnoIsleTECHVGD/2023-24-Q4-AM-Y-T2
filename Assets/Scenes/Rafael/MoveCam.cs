using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class MoveCam : MonoBehaviour
{
    Camera Cam;
    float Xcoord;
    float Ycoord;
    public GameObject destination;
    public GameObject doorstatus;
    public float delaytimer;
    public bool clicked;
    //static bool Isfading;
    public GameObject Blackoutsquare;
    private Animator FadeAnim;
    public float transitiontime;
    PauseMenu pausecheck;
    public GameObject pauseverify;

    private void Start()
    {

        pausecheck = pauseverify.GetComponent<PauseMenu>();
        FadeAnim = Blackoutsquare.GetComponent<Animator>();

    }
    private void OnMouseDown()
    {
        if (pausecheck.pausecheck)
        {

            return;

        }

        Xcoord = destination.transform.position.x;
        Ycoord = destination.transform.position.y;
        Cam = Camera.main;
        FadeAnim.enabled = true;
        FadeAnim.Play("FadeIn");
        Invoke(nameof(MoveRooms), transitiontime);
        GetComponent<BoxCollider2D>().enabled = false;
        clicked = true;


    }

    void MoveRooms()
    {


       
        Cam.transform.position = new Vector3(Xcoord, Ycoord, -100.0f);
        Invoke(nameof(DisableAnim), 0.3f);
        //Isfading = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void DisableAnim()
    {
       
        FadeAnim.enabled = false;
        //Isfading= false;
        clicked = false;

    }

    private void Update()
    {
        if(GetComponent<BoxCollider2D>().enabled == false && !clicked && !doorstatus.GetComponent<NavMeshObstacle>().enabled)
        {

            GetComponent<BoxCollider2D>().enabled = true;


        }
        else if (doorstatus.GetComponent<NavMeshObstacle>().enabled)
        {
            GetComponent<BoxCollider2D>().enabled = false;


        }
        //if (clicked)
        //{
        //    delaytimer -= Time.deltaTime;



        //}
        //else
        //{
        //    delaytimer = 0.5f;

        //}



        //if (delaytimer <= 0.0f)
        //{



        //    clicked = false;

        //}
        //else
        //{


        //}

      



    }

   


    //IEnumerator FadeOut()
    //{
    //    float alphaVal = blackout.color.a;
    //    Color tmp = blackout.color;
    //    Isfading = true;
    //    while (blackout.color.a > 0)
    //    {
    //        alphaVal -= 0.1f;
    //        tmp.a = alphaVal;
    //        blackout.color = tmp;

    //        yield return new WaitForSeconds(0.05f);


    //    }
    //    Isfading = false;

    //}

    //IEnumerator FadeIn()
    //{
    //    float alphaVal = blackout.color.a;
    //    Color tmp = blackout.color;
    //    Isfading = true;
    //    while (blackout.color.a < 1)
    //    {
    //        alphaVal += 0.1f;
    //        tmp.a = alphaVal;
    //        blackout.color = tmp;

    //        yield return new WaitForSeconds(0.05f);


    //    }


    //}




}
