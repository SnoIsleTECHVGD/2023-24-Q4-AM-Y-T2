using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public static int SolveNumber;
    public int pubnumber;
    public DoorCode doorscript, doorscript2, doorscript3;
    public DoorTension dooropen;
    public bool win, winonce;
    public int wincount;
    public ErrorsForRooms errorcheck;
    //[SerializeField] private AudioSource _source;
    //[SerializeField] private AudioClip _completeClip;

    private void Start()
    {

        SolveNumber = 4;
        doorscript = GameObject.Find("MainOffice").GetComponent<DoorCode>();
        doorscript2 = GameObject.Find("Front exit").GetComponent<DoorCode>();
        doorscript3 = GameObject.Find("Observation Room (1)").GetComponent<DoorCode>();
    }
    private void Update()
    {
        errorcheck = GameObject.Find("Main Camera").GetComponent<ErrorsForRooms>();
        pubnumber = SolveNumber;

        if (errorcheck.RoomError == "Front exit (UnityEngine.GameObject)" && errorcheck.ErrorTimer >= 59f || Input.GetKeyDown(KeyCode.Keypad5)) //Opens the vent
        {
            SolveNumber = 0;



        }

        //if(SolveNumber == 4)
        //{

        //    //win = true;
        //    doorscript.GLitchedOutUp = false;
        //}

        //if (SolveNumber == 0)
        //{

           
        //}


        //if (SolveNumber == 0 && !doorscript.upclosed)
        //{
          

        //}


        //if (SolveNumber == 4) //Closes the vent
        //{
            
        //    //errorcheck.IsThereError = false;


        //}

        //if (SolveNumber == 4 && errorcheck.RoomError == "Front exit (UnityEngine.GameObject)")
        //{

        //    errorcheck.RoomError = null;

        //}
        //else
        //{
        //    return;

        //}
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
        SolveNumber = SolveNumber + 1;
        Debug.Log(SolveNumber);
        //return;
        //_source.PlayOneShot(_completeClip);
    }
}
