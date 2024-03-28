using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEntry : MonoBehaviour
{
    public LayerMask Entry;
    public GameObject leftentry;
    public GameObject rightentry;
    public GameObject DoorControl;


    private void Update()
    {
        RaycastHit2D rightentryhit = Physics2D.Raycast(transform.position, Vector2.right, Entry);

        if (rightentryhit.collider != null)
        {

            rightentry = rightentryhit.collider.gameObject;

            if (DoorControl.GetComponent<DoorCode>().rightdoorclosed)
            {
                rightentry.GetComponent<BoxCollider2D>().enabled = false;



            }
            else
            {

                rightentry.GetComponent<BoxCollider2D>().enabled = true;

            }

        }


    }
}
