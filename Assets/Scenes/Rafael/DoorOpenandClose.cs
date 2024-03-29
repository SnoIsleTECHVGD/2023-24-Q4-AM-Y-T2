using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DoorOpenandClose : MonoBehaviour
{
    private float speed = 10.0f;
    private Vector2 target;
    public GameObject DoorTargetOpen;
    public GameObject DoorTargetClose;
    private Vector2 targetclose;
    private Vector2 position;
    public GameObject DoorStatus;

    // Start is called before the first frame update
    void Start()
    {
        target = DoorTargetOpen.transform.position;
        position = transform.position;
        targetclose = DoorTargetClose.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (DoorStatus.GetComponent<NavMeshObstacle>().enabled == false)
        {


            transform.position = Vector2.MoveTowards(transform.position, target, step);


        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, targetclose, step);

        }



       


        
    }
}
