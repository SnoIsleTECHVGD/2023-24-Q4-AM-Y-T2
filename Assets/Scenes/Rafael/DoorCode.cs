using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class DoorCode : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask Door;
    public GameObject leftdoor;
    public GameObject rightdoor;
    public GameObject Player;
    public bool leftdoorclosed;
    public bool rightdoorclosed; 


    private void Update()
    {

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


        if (Player.GetComponent<Animator>().enabled == true)
        {
            leftdoor = null;
            rightdoor = null;



        }



    }

    bool RightDoorClosed()
    {
        if (rightdoor.GetComponent<NavMeshObstacle>().enabled == true) 
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
        if (leftdoor.GetComponent<NavMeshObstacle>().enabled == true)
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

}
