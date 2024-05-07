using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class DoorCode : MonoBehaviour
{
    // Start is called before the first frame update
    //public LayerMask Door, Entry;
    public GameObject leftdoor, rightdoor,vent, leftentry, rightentry, Playerpos/*, Player*/;
    public bool leftdoorclosed, rightdoorclosed,upclosed = true, GlitchedOutLeft, GlitchedOutRight, GLitchedOutUp, GlitchSetLeft = false, GlitchSetRight = false,winonce;
    public float GlitchRandLeft,GlitchRandRight,GlitchRandUp, GlitchResult, rightglitchtime,leftglitchtime,upglitchtime,glitchstore;
    public ErrorsForRooms errorcheck;
    PuzzleSlot puzzlecount;
    public int puzzlecounter;
    PauseMenu pausecheck;
    public GameObject pauseverify;

    private void Start()
    {
        pausecheck = pauseverify.GetComponent<PauseMenu>();
        //winonce = puzzlesolved.win;
        //puzzlecount = GameObject.Find("Puzzle Slot 1(Clone)").GetComponent<PuzzleSlot>();
        errorcheck = GameObject.Find("Main Camera").GetComponent<ErrorsForRooms>();
        //GlitchRandUp = Random.Range(16f, 23f) * 3;
    }
    public void RandomizeValues()
    {

        GlitchRandLeft = Random.Range(10f, 40f);

        GlitchRandRight = Random.Range(5f, 20f) * 2;

        //GlitchRandUp = Random.Range(16f, 23f) * 3;

    }


    //public void RandomizeValuesVent()
    //{

    //    GlitchRandUp = Random.Range(16f, 23f) * 3;





    //}
    private void Update()
    {
        if (pausecheck.pausecheck)
        {

            return;

        }

        //puzzlecounter = puzzlecount.pubnumber;
        //puzzlecount.pubnumber = puzzlecounter;
        //puzzlecount = GameObject.Find("Puzzle Slot 1(Clone)");


        //GlitchRand = Random.Range(10f, 40f);

        //Raycasts to tell which door is which and what the code can do
        //transform.position = new Vector3(Playerpos.transform.position.x, Playerpos.transform.position.y, 0.0f);

        //RaycastHit2D rightentryhit = Physics2D.Raycast(transform.position, Vector2.right, Entry);


        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(transform.position, Playerpos.transform.position) < 0.5)
        {
            rightdoorclosed = RightDoorClosed();
            RandomizeValues();
            //CancelInvoke(nameof(RandomizeValues));

        }

        //RaycastHit rightentryhit;
        //if (Physics.Raycast(transform.position, transform.right, out rightentryhit, 10f, Entry))
        //{
        //    Debug.DrawRay(transform.position, transform.right * 10f, Color.red);
        //    rightentry = rightentryhit.collider.gameObject;

        //    if (rightdoorclosed)
        //    {
        //        rightentry.GetComponent<BoxCollider2D>().enabled = false;



        //    }
        //    else
        //    {

        //        rightentry.GetComponent<BoxCollider2D>().enabled = true;

        //    }


        //}

       

       

       
        if (Input.GetKeyDown(KeyCode.Q) && Vector2.Distance(transform.position, Playerpos.transform.position) < 0.5)
        {
            leftdoorclosed = LeftDoorClosed();
            RandomizeValues();
            //CancelInvoke(nameof(RandomizeValues));

        }

       


        if (puzzlecounter == 4)
        {
            upclosed = true;
            //GLitchedOutUp = false;
            //RandomizeValuesVent();

        }

      

        //IF the door is closed, wait a certain amount of time to open them
        if (leftdoorclosed)
        {
            //RandomizeValues();
            
            leftentry.GetComponent<BoxCollider2D>().enabled = false;
            leftdoor.GetComponent<NavMeshObstacle>().enabled = true;
        }
        else
        {

            leftentry.GetComponent<BoxCollider2D>().enabled = true;
            leftdoor.GetComponent<NavMeshObstacle>().enabled = false;
        }
        
        //if (leftdoorclosed && Input.GetKeyDown(KeyCode.Q) || rightdoorclosed && Input.GetKeyDown(KeyCode.E))
        //{
           

        //}

        

        if (rightdoorclosed)
        {
            //RandomizeValues();
            
            rightentry.GetComponent<BoxCollider2D>().enabled = false;
            rightdoor.GetComponent<NavMeshObstacle>().enabled = true;

        }
        else
        {
            rightentry.GetComponent<BoxCollider2D>().enabled = true;
            rightdoor.GetComponent<NavMeshObstacle>().enabled = false;

        }

        if (upclosed) 
        {
            //upglitchtime = GlitchRandUp;
            //Invoke(nameof(UpGlitch), upglitchtime);
           
            vent.GetComponent<NavMeshObstacle>().enabled = true;

        }
        else
        {

            vent.GetComponent<NavMeshObstacle>().enabled = false;

        }

        if (upclosed && errorcheck.RoomError == "HallwayRoom (UnityEngine.GameObject)")
        {

            UpGlitch();
            
        }

        if (leftdoorclosed)
        {


            leftglitchtime = GlitchRandLeft;
            Invoke(nameof(LeftGlitch), leftglitchtime);
        }


        if (rightdoorclosed)
        {
            rightglitchtime = GlitchRandRight;
            Invoke(nameof(RightGlitch), rightglitchtime);

        }


        // For making the randomized script only happen once so the bool does not constantly generate random values
        //if(puzzlesolved.win == true)
        // {

        //     WinOnce();
        //     CancelInvoke(nameof(WinOnce));

        // }

        //if(winonce == true)
        // {

        //     winonce = false;

        // }



        //If you move rooms, doors update based on the room you're in

        //if (Player.GetComponent<Animator>().enabled == true)
        //{
        //    leftdoor = null;
        //    rightdoor = null;
        //    leftdoorclosed = false;
        //    rightdoorclosed = false;
        //    //vent = null;
        //    //leftentry = null;
        //    //rightentry = null;


        //}

      

       
       

      
       



        if (GlitchedOutLeft && leftdoorclosed)
        {

            leftdoorclosed = false;
            GlitchedOutLeft = false;
            CancelInvoke(nameof(LeftGlitch));
            return;
        }
      
       

        if (GlitchedOutRight && rightdoorclosed)
        {

            rightdoorclosed = false;
            GlitchedOutRight = false;
            CancelInvoke(nameof(RightGlitch));
            return;
        }

        if (GLitchedOutUp && !upclosed)
        {

            //upclosed = false;
            CancelInvoke(nameof(UpGlitch));
            return;


        }







    }

    //Closes and opens left/right door depending on it's current status and whether or not its glitching
    bool RightDoorClosed()
    {
        if (rightdoorclosed) 
        {
            //rightdoor.GetComponent<NavMeshObstacle>().enabled = false;
            return (false);





        }
        else
        {

            //rightdoor.GetComponent<NavMeshObstacle>().enabled = true;
            return (true);

        }




    }

    //bool VentClosed()
    //{
    //    if (upclosed)
    //    {
    //        //rightdoor.GetComponent<NavMeshObstacle>().enabled = false;
    //        return (false);





    //    }
    //    else
    //    {

    //        //rightdoor.GetComponent<NavMeshObstacle>().enabled = true;
    //        return (true);

    //    }




    //}

    bool LeftDoorClosed()
    {
        if (leftdoorclosed)
        {
            //leftdoor.GetComponent<NavMeshObstacle>().enabled = false;
            return (false);





        }
        else
        {

            //leftdoor.GetComponent<NavMeshObstacle>().enabled = true;
            return (true);
            
        }




    }

    //determines if the doors will glitch and open up
    void LeftGlitch()
    {


       
        

        GlitchedOutLeft = true;
       
       
    }

    public void UpGlitch()
    {
        //puzzlecounter = 0;
        GLitchedOutUp = true;
       

    }
    

    void RightGlitch()
    {

       

        GlitchedOutRight = true;
       

    }

    //void WinOnce()
    //{

    //    winonce = true;


    //}
    
}
