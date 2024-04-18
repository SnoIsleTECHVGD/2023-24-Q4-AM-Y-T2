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

    private void Update()
    {

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

        if (leftdoorclosed)
        {

            Invoke(nameof(LeftGlitch), Random.Range(10.0f, 40.0f));

        }
        else
        {

            GlitchedOutLeft = false;
        }

        if (rightdoorclosed)
        {

            Invoke(nameof(RightGlitch), Random.Range(10.0f, 40.0f));


        }
        else
        {

            GlitchedOutRight = false;
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

        if (Player.GetComponent<Animator>().enabled == true)
        {
            leftdoor = null;
            rightdoor = null;
            //leftentry = null;
            //rightentry = null;


        }



    }

    bool RightDoorClosed()
    {
        if (rightdoor.GetComponent<NavMeshObstacle>().enabled == true || GlitchedOutRight) 
        {
            rightdoor.GetComponent<NavMeshObstacle>().enabled = false;
            return (false);





        }
        else
        {

            rightdoor.GetComponent<NavMeshObstacle>().enabled = true;
            return (true);

        }




    }



    bool LeftDoorClosed()
    {
        if (leftdoor.GetComponent<NavMeshObstacle>().enabled == true || GlitchedOutLeft)
        {
            leftdoor.GetComponent<NavMeshObstacle>().enabled = false;
            return (false);





        }
        else
        {

            leftdoor.GetComponent<NavMeshObstacle>().enabled = true;
            return (true);
            
        }




    }

    void LeftGlitch()
    {

        GlitchedOutLeft = true;



    }
    

   void RightGlitch()
    {


        GlitchedOutRight = true;

    }

}
