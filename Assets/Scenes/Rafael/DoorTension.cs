using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


public class DoorTension : MonoBehaviour
{

    private float speed = 1.0f;
    private Vector2 targetclosed, targetOpen;
    public GameObject Stageclosed, StageOpen;
    //public GameObject DoorTargetClose;
    //private Vector2 targetclose;
    private Vector2 position;
    public GameObject DoorStatus;
    float step;
    public static bool errored;
    public static bool permaopen;
    public bool manualerror;
    public bool permacheck;
    // Start is called before the first frame update
    void Start()
    {
        targetclosed = Stageclosed.transform.position;
        position = transform.position;
        targetOpen = StageOpen.transform.position;
        //targetclose = DoorTargetClose.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        errored = manualerror;
        permacheck = permaopen;

        if (errored)
        {
            step = 0.3f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetOpen, step);

        }


        if(Vector2.Distance(transform.position, StageOpen.transform.position) < 0.01)
        {
            DoorStatus.GetComponent<NavMeshObstacle>().enabled = false;
            transform.position = StageOpen.transform.position;
            permaopen = true;


        }

        if (!errored && !permaopen)
        {
            step = 10f * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetclosed, step);

        }


    }


    //void Bad()
    //{
       
    //    transform.position = Vector2.MoveTowards(transform.position, target1, step);
    //    Invoke(nameof(Worse), 0.20f);

    //}

    //void Worse()
    //{

    //    transform.position = Vector2.MoveTowards(transform.position, target2, step);
    //    Invoke(nameof(OhGod), 0.20f);

    //}


    //void OhGod()
    //{

    //    transform.position = Vector2.MoveTowards(transform.position, target3, step);

    //}
}
