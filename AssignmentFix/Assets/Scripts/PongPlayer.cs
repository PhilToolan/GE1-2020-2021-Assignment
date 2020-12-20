using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayer : MonoBehaviour
{

    public Camera camera2D;
    public LayerMask layerMaskFloor;
    public LayerMask layerMaskWall;
    public GameObject paddleFloor;
    public GameObject paddleWall;
    public int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation of "target"
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = camera2D.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        RaycastHit2D hitFloor = Physics2D.Raycast(transform.position, transform.right, 20, layerMaskFloor);
        //Debug.DrawRay(transform.position, transform.right * 20, Color.green);

        RaycastHit2D hitWall = Physics2D.Raycast(transform.position, transform.right, 20, layerMaskWall);
        //Debug.DrawRay(transform.position, transform.right * 20, Color.green);

        //If something was hit, the raycast.collider will not be null
        if (hitFloor.collider != null)
        {
            if (hitFloor.point.y < 0)
            {
                paddleFloor.transform.position = new Vector3(hitFloor.point.x, -4.88f);
            }
            else //Snap to ceiling
            {
                paddleFloor.transform.position = new Vector3(hitFloor.point.x, 4.88f);
            }
        }

        //If something was hit, the raycast.collider will not be null
        if (hitWall.collider != null)
        {
            if (hitWall.point.x < 0)
            {
                paddleWall.transform.position = new Vector3(-8.68f, hitWall.point.y);
            }
            else //Snap to other side
            {
                paddleWall.transform.position = new Vector3(8.68f, hitWall.point.y);
            }
        }
    }
}
