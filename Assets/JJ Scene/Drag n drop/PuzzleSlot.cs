using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public int SlotIndex = 0;

    //[SerializeField] private AudioSource _source;
    //[SerializeField] private AudioClip _completeClip;

    public void Placed()
    {
        SlotIndex++;
        return;
        //_source.PlayOneShot(_completeClip);
    }

  

}
