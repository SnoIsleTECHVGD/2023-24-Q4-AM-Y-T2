using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public static int SolveNumber;
    public int pubnumber;
    public DoorCode doorscript;

    //[SerializeField] private AudioSource _source;
    //[SerializeField] private AudioClip _completeClip;

    private void Start()
    {

        //SolveNumber = 4;
        doorscript = GameObject.Find("Target").GetComponent<DoorCode>();

    }
    private void Update()
    {

        pubnumber = SolveNumber;
        SolveNumber = pubnumber;

    }

    public void Placed()
    {
        SolveNumber++;
        Debug.Log(SolveNumber);
        //return;
        //_source.PlayOneShot(_completeClip);
    }

  

}
