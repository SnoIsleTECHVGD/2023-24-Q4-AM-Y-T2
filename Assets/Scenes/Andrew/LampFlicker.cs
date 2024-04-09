using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampFlicker : MonoBehaviour
{
    public Light2D Lamp;
    private float random;

    private void Start()
    {
        random = Random.Range(0.0f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        float maxInt = 8.2f;
        float minInt = 1.0f;
        float noise = Mathf.PerlinNoise(random, Time.time);

        Lamp.intensity = Mathf.Lerp(minInt,maxInt, noise);
    }
}
