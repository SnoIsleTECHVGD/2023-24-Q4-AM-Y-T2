using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public static int SolveNumber;
    public int pubnumber;
    public DoorCode doorscript;
    public bool win,winonce;
    public int wincount;

    //[SerializeField] private AudioSource _source;
    //[SerializeField] private AudioClip _completeClip;

    private void Start()
    {

        SolveNumber = 4;
        doorscript = GameObject.Find("Target").GetComponent<DoorCode>();

    }
    private void Update()
    {

        pubnumber = SolveNumber;

        if (doorscript.GLitchedOutUp)
        {
            SolveNumber = 0;



        }

        if(SolveNumber == 4)
        {

            //win = true;
            doorscript.GLitchedOutUp = false;
        }

        //if(win)
        // {

        //     WinOnce();
        //     CancelInvoke(nameof(WinOnce));

        // }

        //if(winonce == true)
        // {

        //     winonce = false;

        // }

    }


    //void WinOnce()
    //{

    //    winonce = true;


    //}
    public void Placed()
    {
        SolveNumber++;
        Debug.Log(SolveNumber);
        //return;
        //_source.PlayOneShot(_completeClip);
    }

  

}
