using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightChange : MonoBehaviour
{
    Color color0 = Color.red;
    Color color1 = Color.blue;

    Light lt;

    public int band;
    private float maxVal;
    private float audioVal;
    private float lerpVal;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        // set light color
        //float t = Mathf.PingPong(Time.time, duration) / duration;
        //lt.color = Color.Lerp(color0, color1, t);
        //audioVal = AudioAnalyzer.bands[band];

        //if (audioVal > maxVal)
        //{
        //    maxVal = audioVal;
        //}

        lerpVal = Mathf.Lerp(lerpVal, 1 + (AudioAnalyzer.bands[band] * 3), Time.deltaTime);

        if (lerpVal > 2.2)
        {
            lt.color = color0;
            //ChangeColour();
        }
        else if (lerpVal < 2.2)
        {
            lt.color = color1;
        }


        //Debug.Log(AudioAnalyzer.bands[band]);
        //Debug.Log(maxVal);
        //Debug.Log(lerpVal);
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
