using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Emergencyscript : MonoBehaviour
{

    public DoorCode doorscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        doorscript = GameObject.Find("Front exit").GetComponent<DoorCode>();

        if (!doorscript.upclosed)
        {


            GetComponent<NavMeshObstacle>().enabled = false;

        }
        else
        {

            GetComponent<NavMeshObstacle>().enabled = true;

        }
        
    }
}
