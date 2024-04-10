using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    private Light2D Light;
    private ErrorsForRooms errors;
    private float random;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0.0f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        if(errors.isMontiorOn)
            Light = errors._mapLights[errors.RoomNumber];
        if (!errors.isMontiorOn)
            Light = errors._mapLights[7];

        float maxInt = 15.2f;
        float minInt = 2.0f;
        float noise = Mathf.PerlinNoise(random, Time.time * 20);

        Light.intensity = Mathf.Lerp(minInt, maxInt, noise);
    }
}
