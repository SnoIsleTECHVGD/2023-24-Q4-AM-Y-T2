using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class DoorCode : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask Door;
    public LayerMask Entry;
    public GameObject leftdoor;
    public GameObject rightdoor;
    public GameObject leftentry;
    public GameObject rightentry;
    public GameObject Player;
    public bool leftdoorclosed;
    public bool rightdoorclosed;
    public bool GlitchedOutLeft;
    public bool GlitchedOutRight;
    public GameObject Playerpos;

    public float glitchleft;
    public float glitchright;

    private void Update()
    {
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

        //IF the door is closed, wait a certain amount of time to open them
        if (leftdoorclosed)
        {
            float jedd = Random.Range(6.0f, 40f);
            Invoke(nameof(LeftGlitch), jedd);

        }
       
       

        if (rightdoorclosed)
        {
            float otherjedd = Random.Range(6.0f, 40f);
            Invoke(nameof(RightGlitch), otherjedd);


        }
       
       
       

        //RaycastHit leftentryhit;
        //if (Physics.Raycast(transform.position, transform.right, out leftentryhit, 10f, Entry))
        //{
        //    Debug.DrawRay(transform.position, transform.right * 10f, Color.red);
        //    leftentry = leftentryhit.collider.gameObject;

        //    if (leftdoorclosed)
        //    {
        //        leftentry.GetComponent<BoxCollider2D>().enabled = false;



        //    }
        //    else
        //    {

        //        leftentry.GetComponent<BoxCollider2D>().enabled = true;

        //    }


        //}

        //If you move rooms, doors update based on the room you're in

        if (Player.GetComponent<Animator>().enabled == true)
        {
            leftdoor = null;
            rightdoor = null;
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
       
       
        if (GlitchedOutLeft ||GlitchedOutRight)
        {

            

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

    

    void RightGlitch()
    {

       

        GlitchedOutRight = true;
       

    }
    
}
