using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    Camera Cam;
    float Xcoord;
    float Ycoord;
    public GameObject destination;

  
    private void OnMouseDown()
    {
        Cam = Camera.main;

        Xcoord = destination.transform.position.x;
        Ycoord = destination.transform.position.y;
        Cam.transform.position = new Vector3(Xcoord, Ycoord, -100.0f);
        


    }


}
