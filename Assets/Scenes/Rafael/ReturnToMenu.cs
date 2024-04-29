using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{

    public GameObject fadingguy;
    public Animator Fading;

    private void OnMouseDown()
    {
        Fading = fadingguy.GetComponent<Animator>();

        Fading.enabled = true;
        Fading.Play("WinFade");
        Invoke(nameof(GoToMenu), 1f);




    }

    void GoToMenu()
    {

        SceneManager.LoadScene("Menu");

    }



}
