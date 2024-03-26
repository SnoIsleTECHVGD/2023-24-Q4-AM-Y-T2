using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class MoveCam : MonoBehaviour
{
    Camera Cam;
    float Xcoord;
    float Ycoord;
    public GameObject destination;
    public float delaytimer;
    public bool clicked;
    public SpriteRenderer blackout;
    static bool Isfading;
    public GameObject Blackoutsquare;
    private Animator FadeAnim;
    public float transitiontime;

    private void Start()
    {


        FadeAnim = Blackoutsquare.GetComponent<Animator>();

    }
    private void OnMouseDown()
    {

        Xcoord = destination.transform.position.x;
        Ycoord = destination.transform.position.y;
        clicked = true;
        Cam = Camera.main;
        FadeAnim.enabled = true;
        FadeAnim.Play("FadeIn");
        Invoke(nameof(MoveRooms), transitiontime);




    }

    void MoveRooms()
    {



        Cam.transform.position = new Vector3(Xcoord, Ycoord, -100.0f);
        Invoke(nameof(DisableAnim), 0.7f);
        Isfading = true;
    }

    void DisableAnim()
    {

        FadeAnim.enabled = false;
        Isfading= false;


    }

    private void Update()
    {

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



        if (Isfading)
        {

            GetComponent<BoxCollider2D>().enabled = false;

        }
        else
        {

            GetComponent<BoxCollider2D>().enabled = true;

        }

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
