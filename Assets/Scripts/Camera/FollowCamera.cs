using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;
    public GameObject ethan;
    public Vector3 offset;

    private float mouseX;
    private float mouseY;
    private float mouseZ;

    public Camera ThirdCam;
    public Camera TopDownCam;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        mouseZ = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.Euler(0, mouseX, 0) * offset;
        }

        float angleBetween = Vector3.Angle(Vector3.up, transform.forward);

        if (Input.GetMouseButton(0))
        {
            if ((angleBetween > 100.0f) && (mouseY < 0) || (angleBetween < 140.0f) && (mouseY > 0))
            {
                Vector3 localRight = target.transform.worldToLocalMatrix.MultiplyVector(transform.right);
                offset = Quaternion.AngleAxis(mouseY, localRight) * offset;
            }
        }

        float dist = Vector3.Distance(target.transform.position, transform.position);

            if ((mouseZ > 0) && (dist < 10))
            {
                offset = Vector3.Scale(offset, new Vector3(1.05f, 1.05f, 1.05f));
            }

            if ((mouseZ < 0) && (dist > 1))
            {
                offset = Vector3.Scale(offset, new Vector3(0.95f, 0.95f, 0.95f));
            }

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position + (rotation * offset);
        transform.LookAt(target.transform);

        if (ThirdCam.enabled == true)
        {
            Ray thirdRay = new Ray(transform.position, (ethan.transform.position - transform.position) + new Vector3(0, 1.5f, 0));
            RaycastHit hitData;
            Physics.Raycast(thirdRay, out hitData);

            if (hitData.collider.tag == "Player")
            { 
                ThirdCam.enabled = true;
                TopDownCam.enabled = false;
            }

            else
            {
                ThirdCam.enabled = false;
                TopDownCam.enabled = true;
            }
        }

        else if (TopDownCam.enabled == true)
        {
          //  Debug.DrawRay(transform.position, (ethan.transform.position - transform.position) + new Vector3(0,1.5f,0), color: Color.black);
            Ray topRay = new Ray(transform.position, ethan.transform.position - transform.position);
            RaycastHit hitData;
            Physics.Raycast(topRay, out hitData);

            if (hitData.collider.tag == "Player")
            {
                ThirdCam.enabled = true;
                TopDownCam.enabled = false;
            }

            else
            {
                ThirdCam.enabled = false;
                TopDownCam.enabled = true;
            }
        }
    }

} 
