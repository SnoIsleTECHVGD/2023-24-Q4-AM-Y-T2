using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampFlicker : MonoBehaviour
{
    public Light2D Light;
    private float random;

    public float AcceratedTime;

    private void Start()
    {
        random = Random.Range(0.0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        float maxxyMouse = 15.2f;
        float minnyMouse = 2.0f;
        float noise = Mathf.PerlinNoise(random, Time.time * AcceratedTime);

        Light.intensity = Mathf.Lerp(minnyMouse,maxxyMouse, noise);
    }
}
