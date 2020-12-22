using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    private float startScale = 1; 
    public float scaleMultiplier;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ls = transform.localScale;
        ls.y = Mathf.Lerp(ls.y, 1 + (AudioAnalyzer.bands[band] * scaleMultiplier), Time.deltaTime * startScale);
        transform.localScale = ls;
        Vector3 pos = transform.position;
        pos.y = startPosition.y + (ls.y / 2);
        transform.position = pos;
        //transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(1 + (AudioAnalyzer.bands[band] * scaleMultiplier) + startScale * Time.deltaTime * 3.0), transform.localScale.z);
        //(AudioAnalyzer.bands[band] * scaleMultiplier) + startScale
    }
}
