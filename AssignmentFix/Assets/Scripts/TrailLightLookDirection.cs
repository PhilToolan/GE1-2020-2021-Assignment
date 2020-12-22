using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailLightLookDirection : MonoBehaviour
{

    public Transform sphere;
    public float rotSpeed = 180;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toSphere = sphere.transform.position - transform.position;


        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toSphere), rotSpeed * Time.deltaTime);

    }
}
