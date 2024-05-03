using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampFlicker : MonoBehaviour
{
    public Light2D Light;
    private float random;

    public float AcceratedTime;

    public float maxIntensity;
    public float minIntensity;


    private void Start()
    {
        random = Random.Range(0.0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        float noise = Mathf.PerlinNoise(random, Time.time * AcceratedTime);

        Light.intensity = Mathf.Lerp(minIntensity,maxIntensity, noise);
    }
}
