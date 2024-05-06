using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class PuzzleColor : MonoBehaviour
{
    // Start is called before the first frame update
    public string TargetDoor;
    private GameObject targetPuzzle;
    private Light2D PossibleJunkJoke;

    // Start is called before the first frame update
    void Start()
    {
        //Please name the correct object
        targetPuzzle = GameObject.FindWithTag("ContainRoom");
        PossibleJunkJoke = GetComponent<Light2D>(); //This is the current object, dont ever change this code or I will sacrifice you to the Unity Gods
    }

    // Update is called once per frame
    void Update()
    {
        //NAME THE CORRECT OBJECT, I SWEAR TO ALL THAT IS HOLY. I WON'T TAKE ANY BLAME FOR THIS. IT IS YOUR OWN MISTAKE FOOLS
        if (targetPuzzle.GetComponent<DoorTension>().manualerror) //LOOK FOR THIS COMPONENT!!! IF IT DOESN'T HAVE THIS COMPONENT MUST MEAN YOU SHOULDN'T NAME IT. Thank you <3
        {
            PossibleJunkJoke.color = Color.red;
        }
        else
        {
            PossibleJunkJoke.color = Color.green;
        }
    }
}
