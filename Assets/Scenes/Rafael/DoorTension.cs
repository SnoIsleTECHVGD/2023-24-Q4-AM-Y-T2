using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class DoorTension : MonoBehaviour
{

    private float speed = 10.0f;
    private Vector2 target1,target2,target3;
    public GameObject Stage1,Stage2,Stage3;
    public GameObject DoorTargetClose;
    private Vector2 targetclose;
    private Vector2 position;
    public GameObject DoorStatus;
    float step;
    public bool errored;
    // Start is called before the first frame update
    void Start()
    {
        target1 = Stage1.transform.position;
        target2 = Stage2.transform.position;
        target3 = Stage3.transform.position;
        position = transform.position;

        targetclose = DoorTargetClose.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (errored)
        {
            step = speed * Time.deltaTime;
            Invoke(nameof(Bad),0.20f);

        }
    }


    void Bad()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, target1, step);
        Invoke(nameof(Worse), 0.20f);

    }

    void Worse()
    {

        transform.position = Vector2.MoveTowards(transform.position, target2, step);
        Invoke(nameof(OhGod), 0.20f);

    }


    void OhGod()
    {

        transform.position = Vector2.MoveTowards(transform.position, target3, step);

    }
}
