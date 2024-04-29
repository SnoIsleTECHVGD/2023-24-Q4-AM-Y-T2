using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class DoorCode : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask Door, Entry;
    public GameObject leftdoor, rightdoor,vent, leftentry, rightentry, Playerpos, Player;
    public bool leftdoorclosed, rightdoorclosed,upclosed = true, GlitchedOutLeft, GlitchedOutRight, GLitchedOutUp, GlitchSetLeft = false, GlitchSetRight = false,winonce;
    public float GlitchRandLeft,GlitchRandRight,GlitchRandUp, GlitchResult, rightglitchtime,leftglitchtime,upglitchtime,glitchstore;
    
    PuzzleSlot puzzlecount;
    public int puzzlecounter;

    private void Start()
    {

        //winonce = puzzlesolved.win;
        puzzlecount = GameObject.Find("Puzzle Slot 1(Clone)").GetComponent<PuzzleSlot>();
        
        GlitchRandUp = Random.Range(16f, 23f) * 3;
    }
    public void RandomizeValues()
    {

        GlitchRandLeft = Random.Range(10f, 40f);

        GlitchRandRight = Random.Range(5f, 20f) * 2;

        GlitchRandUp = Random.Range(16f, 23f) * 3;

    }


    public void RandomizeValuesVent()
    {

        GlitchRandUp = Random.Range(16f, 23f) * 3;





    }
    private void Update()
    {
        puzzlecounter = puzzlecount.pubnumber;
        puzzlecount.pubnumber = puzzlecounter;
        //puzzlecount = GameObject.Find("Puzzle Slot 1(Clone)");


        //GlitchRand = Random.Range(10f, 40f);

        //Raycasts to tell which door is which and what the code can do
        transform.position = new Vector3(Playerpos.transform.position.x, Playerpos.transform.position.y, 0.0f);
        
        RaycastHit2D rightentryhit = Physics2D.Raycast(transform.position, Vector2.right, Entry);

        if (rightentryhit.collider != null)
        {

            rightentry = rightentryhit.collider.gameObject;

            if (rightdoorclosed)
            {
                rightentry.GetComponent<BoxCollider2D>().enabled = false;



            }
            else
            {

                rightentry.GetComponent<BoxCollider2D>().enabled = true;

            }

        }
        RaycastHit righthit;
        if (Physics.Raycast(transform.position, transform.right, out righthit, 10f, Door))
        {
            Debug.DrawRay(transform.position, transform.right*10f, Color.red);
            rightdoor = righthit.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                rightdoorclosed = RightDoorClosed();


            }


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

        RaycastHit2D leftentryhit = Physics2D.Raycast(transform.position, -Vector2.right, 10.0f,Entry);

        if (leftentryhit.collider != null)
        {

            leftentry = leftentryhit.collider.gameObject;

            if (leftdoorclosed)
            {
                leftentry.GetComponent<BoxCollider2D>().enabled = false;



            }
            else 
            {

                leftentry.GetComponent<BoxCollider2D>().enabled = true;

            }

        }

        RaycastHit lefthit;
        if (Physics.Raycast(transform.position, -transform.right, out lefthit, 10f, Door))
        {
            Debug.DrawRay(transform.position, -transform.right*10f, Color.red);

            leftdoor = lefthit.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                leftdoorclosed = LeftDoorClosed();


            }


        }


        RaycastHit uphit;
        if (Physics.Raycast(transform.position, transform.up, out uphit, 10f, Door))
        {
            Debug.DrawRay(transform.position, transform.up * 10f, Color.red);

            vent = uphit.collider.gameObject;

           



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
            leftglitchtime = GlitchRandLeft;
            Invoke(nameof(LeftGlitch), leftglitchtime);

        }
        
        if (leftdoorclosed && Input.GetKeyDown(KeyCode.Q) || rightdoorclosed && Input.GetKeyDown(KeyCode.E))
        {
            RandomizeValues();
            CancelInvoke(nameof(RandomizeValues));

        }

        

        if (rightdoorclosed)
        {
            //RandomizeValues();
            rightglitchtime = GlitchRandRight;
            Invoke(nameof(RightGlitch), rightglitchtime);


        }
       
        if (upclosed) 
        { 
            upglitchtime = GlitchRandUp;
            Invoke(nameof(UpGlitch), upglitchtime);


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

        if (Player.GetComponent<Animator>().enabled == true)
        {
            leftdoor = null;
            rightdoor = null;
            //vent = null;
            //leftentry = null;
            //rightentry = null;


        }

        if (rightdoorclosed)
        {

            rightdoor.GetComponent<NavMeshObstacle>().enabled = true;


        }
        else
        {

            rightdoor.GetComponent<NavMeshObstacle>().enabled = false;

        }

        if (upclosed)
        {

            vent.GetComponent<NavMeshObstacle>().enabled = true;


        }
        else
        {

            vent.GetComponent <NavMeshObstacle>().enabled = false;

        }

        if (leftdoorclosed)
        {

            leftdoor.GetComponent<NavMeshObstacle>().enabled = true;


        }
        else
        {

            leftdoor.GetComponent<NavMeshObstacle>().enabled = false;

        }



        if (GlitchedOutLeft)
        {

            leftdoorclosed = false;
            GlitchedOutLeft = false;
            CancelInvoke(nameof(LeftGlitch));
            return;
        }
      
       

        if (GlitchedOutRight)
        {

            rightdoorclosed = false;
            GlitchedOutRight = false;
            CancelInvoke(nameof(RightGlitch));
            return;
        }

        //if (GLitchedOutUp)
        //{

        //    //upclosed = false;
        //    GLitchedOutUp = false;
        //    CancelInvoke(nameof(UpGlitch));
        //    return;


        //}

        if (puzzlecounter < 4)
        {

            upclosed = false;

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

    void UpGlitch()
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
