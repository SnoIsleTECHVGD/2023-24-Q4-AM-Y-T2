using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    Camera Cam;
    float Xcoord;
    float Zcoord;
    public GameObject destination;

  
    private void OnMouseDown()
    {
        Cam = Camera.main;

        Xcoord = destination.transform.position.x;
        Zcoord = destination.transform.position.z;
        Cam.transform.position = new Vector2(Xcoord, Zcoord);
        


    }


}
