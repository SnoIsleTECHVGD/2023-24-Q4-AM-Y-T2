using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    public float MinTime;
    public float MaxTime;
    public float Timer;

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
        if(errors.IsThereError)
        {
            if(errors.isMontiorOn)
                LightFlicker(errors._mapLights[errors.RoomNumber]);
            if(!errors.isMontiorOn)
                LightFlicker(errors._mapLights[7]);
        }
    }

    void LightFlicker(Light2D _light)
    {
        if(Timer > 0)
            Timer -= Time.deltaTime;
        else
        {
            _light.enabled = !_light.enabled;
            Timer = Random.Range(MinTime, MaxTime);
            //AudioSource.PlayOneShot(lightAudio);
        }
    }
}
