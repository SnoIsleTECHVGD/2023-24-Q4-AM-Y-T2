using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    private GameObject[] _light;
    public float MinTime;
    public float MaxTime;
    public float Timer;

    [SerializeField, HideInInspector]
    private ErrorsForRooms errors;

    //public AudioSource AudioSource; //IDK yet...nvm, figured it out. It is the source that will play the noise. DUH!
    //public AudioClip lightAudio; //The beeping sound for the error occuring

    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(errors.RoomNumber > 0)
        {
            //_light = errors._mapLights[errors.RoomNumber];ss
        }
        else
        {
            _light = GameObject.FindGameObjectsWithTag("ErrorLight");
        }

        LightFlicker();
    }

    void LightFlicker()
    {
        if(Timer > 0)
            Timer -= Time.deltaTime;

        if(Timer<= 0)
        {
            //_light.enabled = !_light.enabled;
            Timer = Random.Range(MinTime, MaxTime);
            //AudioSource.PlayOneShot(lightAudio);
        }
    }
}
