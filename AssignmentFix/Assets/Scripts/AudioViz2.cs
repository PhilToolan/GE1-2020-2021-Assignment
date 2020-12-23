using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioViz2 : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;

    public float degree, scale;
    public int numberStart;
    public int stepSize;
    public int maxIteration;

    //Lerping
    public bool useLerping;
    private bool isLerping;
    private Vector3 startPosition, endPosition;
    private float lerpPosTimer, lerpPosSpeed;
    public Vector2 lerpPosSpeedMinMax;
    public AnimationCurve lerpPosAnimCurve;
    public int lerpPosBand;

    private int number;
    private int currentIteration;
    private Vector2 CalculatePhyllotaxis(float degree, float scale, int number)
    {
        double angle = number * (degree * Mathf.Deg2Rad);
        float r = scale * Mathf.Sqrt(number);
        float x = r * (float)System.Math.Cos(angle);
        float y = r * (float)System.Math.Sin(angle);
        Vector2 vec2 = new Vector2(x, y);
        return vec2;
    }
    private Vector2 phyllotaxisPosition;

    private bool forward;
    public bool repeat, invert;

    //Scaling
    public bool useScaleAnimation, useScaleCurve;
    public Vector2 scaleAnimMinMax;
    public AnimationCurve scaleAnimCurve;
    public float scaleAnimSpeed;
    public int scaleBand;
    private float scaleTimer, currentScale;







    void SetLerpPositions()
    {
        phyllotaxisPosition = CalculatePhyllotaxis(degree, currentScale, number);
        startPosition = this.transform.localPosition;
        if (!float.IsNaN(phyllotaxisPosition.x) && !float.IsNaN(phyllotaxisPosition.y))
        {
            endPosition = new Vector3(phyllotaxisPosition.x, phyllotaxisPosition.y, 0);
        }
    }

    // Use this for initialization
    void Awake()
    {
        currentScale = scale;
        forward = true;
        number = numberStart;
        transform.localPosition = CalculatePhyllotaxis(degree, currentScale, number);
        if (useLerping)
        {
            isLerping = true;
            SetLerpPositions();
        }
    }

    private void Update()
    {
        if (useScaleAnimation)
        {
            if (useScaleCurve)
            {
                scaleTimer += (scaleAnimSpeed * AudioAnalyzer.bands[scaleBand]) * Time.deltaTime;
                if (scaleTimer >= 1)
                {
                    scaleTimer -= 1;
                }
                currentScale = Mathf.Lerp(scaleAnimMinMax.x, scaleAnimMinMax.y, scaleAnimCurve.Evaluate(scaleTimer));
            }
            else
            {
                currentScale = Mathf.Lerp(scaleAnimMinMax.x, scaleAnimMinMax.y, AudioAnalyzer.bands[scaleBand]);
            }
        }


        if (useLerping)
        {
            if (isLerping)
            {
                lerpPosSpeed = Mathf.Lerp(lerpPosSpeedMinMax.x, lerpPosSpeedMinMax.y, lerpPosAnimCurve.Evaluate(AudioAnalyzer.bands[lerpPosBand]));
                lerpPosTimer += Time.deltaTime * lerpPosSpeed;
                transform.localPosition = Vector3.Lerp(startPosition, endPosition, Mathf.Clamp01(lerpPosTimer));
                if (lerpPosTimer >= 1)
                {
                    lerpPosTimer -= 1;
                    if (forward)
                    {
                        number += stepSize;
                        currentIteration++;
                    }
                    else
                    {
                        number -= stepSize;
                        currentIteration--;
                    }
                    if ((currentIteration >= 0) && (currentIteration < maxIteration))
                    {
                        SetLerpPositions();
                    }
                    else // current iteration has hit 0 or maxiteration
                    {
                        if (repeat)
                        {
                            if (invert)
                            {
                                forward = !forward;
                                SetLerpPositions();
                            }
                            else
                            {
                                number = numberStart;
                                currentIteration = 0;
                                SetLerpPositions();
                            }
                        }
                        else
                        {
                            isLerping = false;
                        }
                    }
                }

            }
        }
        if (!useLerping)
        {
            phyllotaxisPosition = CalculatePhyllotaxis(degree, currentScale, number);
            transform.localPosition = new Vector3(phyllotaxisPosition.x, phyllotaxisPosition.y, 0);
            number += stepSize;
            currentIteration++;
        }
    }

}
