using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public bool viz1 = true;
    public float rotSpeed = 180;
    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            LookAtVisual();
        }
    }

    void LookAtVisual()
    {
        if (viz1 == true)
        {
            Vector3 toTarget = target1.transform.position - transform.position;


            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toTarget), rotSpeed * Time.deltaTime);
            viz1 = false;
        }

        if (viz1 == false)
        {

            Vector3 toTarget = target2.transform.position - transform.position;


            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toTarget), rotSpeed * Time.deltaTime);
            viz1 = true;
        }
    }
}
