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
    public static bool clicked;
    public bool clickcheck;
    //static bool Isfading;
    public GameObject Blackoutsquare;
    private Animator FadeAnim;
    public float transitiontime;
    PauseMenu pausecheck;
    public GameObject pauseverify;

    private void Start()
    {

        
        FadeAnim = Blackoutsquare.GetComponent<Animator>();

    }
    private void OnMouseDown()
    {
      

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

    }

    void DisableAnim()
    {
       
        FadeAnim.enabled = false;
        //Isfading= false;
    
        Invoke(nameof(CanClickAgain), 0.03f);

    }


    void CanClickAgain()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        clicked = false;

    }
    private void Update()
    {

       
        clickcheck = clicked;
        pausecheck = pauseverify.GetComponent<PauseMenu>();
        if (pausecheck.pausecheck)
        {

            return;

        }
        //if (GetComponent<BoxCollider2D>().enabled == false &&  !doorstatus.GetComponent<NavMeshObstacle>().enabled)
        //{

        //    


        //}

        if ( GetComponent<BoxCollider2D>().enabled == true && clicked)
        {


            GetComponent<BoxCollider2D>().enabled = false;
        }

        if (doorstatus.GetComponent<NavMeshObstacle>().enabled || clicked)
        {
            GetComponent<BoxCollider2D>().enabled = false;


        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;

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
