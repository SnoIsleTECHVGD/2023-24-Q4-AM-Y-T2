using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bruhngus : MonoBehaviour
{
    public GameObject fadingguy;
    public Animator Fading;
    public int scenenum;

    public void OpenScene()
    {
        
        Fading = fadingguy.GetComponent<Animator>();

        Fading.enabled = true;
        Fading.Play("WinFade");
        Invoke(nameof(OkNowGo), 1f);

        
    }

    public void OkNowGo()
    {
        
        SceneManager.LoadScene(scenenum);


    }
}
