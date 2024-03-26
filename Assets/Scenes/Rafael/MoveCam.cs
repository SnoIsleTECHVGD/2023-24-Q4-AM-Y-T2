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


    private void OnMouseDown()
    {

        Xcoord = destination.transform.position.x;
        Ycoord = destination.transform.position.y;
        clicked = true;
        Cam = Camera.main;
       
        





    }

    private void Update()
    {

        if (clicked)
        {
            delaytimer -= Time.deltaTime;
            StartCoroutine(FadeIn());
            

        }
        else
        {
            delaytimer = 1.0f;

        }

        

        if(delaytimer <= 0.0f)
        {

            StartCoroutine(FadeOut());
            Cam.transform.position = new Vector3(Xcoord, Ycoord, -100.0f);
            clicked = false;
            
        }



        if (Isfading) {
            {



            } }

    }


    IEnumerator FadeOut()
    {
        float alphaVal = blackout.color.a;
        Color tmp = blackout.color;
        Isfading = true;
        while (blackout.color.a > 0)
        {
            alphaVal -= 0.1f;
            tmp.a = alphaVal;
            blackout.color = tmp;

            yield return new WaitForSeconds(0.05f);


        }
        Isfading = false;

    }

    IEnumerator FadeIn()
    {
        float alphaVal = blackout.color.a;
        Color tmp = blackout.color;
        Isfading = true;
        while (blackout.color.a < 1)
        {
            alphaVal += 0.1f;
            tmp.a = alphaVal;
            blackout.color = tmp;

            yield return new WaitForSeconds(0.05f);


        }


    }

   


}
