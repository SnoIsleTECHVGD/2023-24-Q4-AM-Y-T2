using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Audioloop : MonoBehaviour
{
    public AudioClip menu;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = menu;
        audioSource.loop = true;
        audioSource.Play();
    }
}
