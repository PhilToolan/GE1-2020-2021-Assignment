using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightChange : MonoBehaviour
{
    // Interpolate light color between two colors back and forth
    float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = Color.blue;

    Light lt;

    public int band;

    void Start()
    {
        lt = GetComponent<Light>();
        lt.color = color1;
    }

    void Update()
    {
        // set light color
        //float t = Mathf.PingPong(Time.time, duration) / duration;
        //lt.color = Color.Lerp(color0, color1, t);

        if (AudioAnalyzer.bands[band] > 0.3)
        {
            ChangeColour();
        }

        //Debug.Log(AudioAnalyzer.bands[band]);
    }

    void ChangeColour()
    {
        if (lt.color == color0)
        {
            lt.color = color1;
        }
        else if (lt.color == color1)
        {
            lt.color = color0;
        }
    }
}
