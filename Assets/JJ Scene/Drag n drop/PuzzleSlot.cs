using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;
    static int SolveNumber;
    public int pubnumber;

    //[SerializeField] private AudioSource _source;
    //[SerializeField] private AudioClip _completeClip;

    private void Start()
    {

        pubnumber = 4;

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
