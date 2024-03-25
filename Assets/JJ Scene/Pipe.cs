using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField]
    bool isPlaced = false;

    int PossibleRots = 1;

    win win;


    private void Awake()
    {
        win = GameObject.Find("win").GetComponent<win>();
    }
    private void Start()
    {
        PossibleRots = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if(PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                win.correctMove();
            }
            
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                win.correctMove();
            }
        }
   
    }
    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));
        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && isPlaced == false)
            {
                isPlaced = true;
                win.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                win.wrongMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0] && isPlaced == false)
            {
                isPlaced = true;
                win.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                win.wrongMove();
            }
        }
    }
}
