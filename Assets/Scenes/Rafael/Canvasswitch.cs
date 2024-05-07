using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvasswitch : MonoBehaviour
{
    public Canvas menucanvas;
    public Canvas tutorialmenu;
    
  public void GoTutorial()
    {

        menucanvas.enabled = false;
        tutorialmenu.enabled = true;

    }

    void GoMenu()
    {



    }



}
