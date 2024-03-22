using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    public Light2D _light;

    public float MinTime;
    public float MaxTime;
    public float Timer;

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
        LightFlicker();
    }

    void LightFlicker()
    {
        if(Timer > 0)
            Timer -= Time.deltaTime;

        if(Timer<= 0)
        {
            _light.enabled = !_light.enabled;
            Timer = Random.Range(MinTime, MaxTime);
            //AudioSource.PlayOneShot(lightAudio);
        }
    }
}
