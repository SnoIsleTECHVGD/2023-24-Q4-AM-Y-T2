using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureSetAnim : MonoBehaviour
{
    SpriteRenderer currentcreature;
    public Sprite doorwalk;
    public Sprite ventcrawl;


    // Start is called before the first frame update
    void Start()
    {
        currentcreature = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("ThroughDoor"))
        {
            currentcreature.sprite = doorwalk;

        }

        if (other.gameObject.CompareTag("ThroughVent"))
        {
            currentcreature.sprite = ventcrawl;

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
