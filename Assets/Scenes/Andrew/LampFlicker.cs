using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampFlicker : MonoBehaviour
{
    public Light2D Lamp;

    // Update is called once per frame
    void Update()
    {
        Lamp.intensity = Mathf.PingPong(Time.time, 6f);
    }
}
