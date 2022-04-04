using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;


    public void Start()
    {
        offset = transform.position + target.transform.position;
        target = GameObject.Find("CameraTarget");
    }

    private void LateUpdate()
    {
        if (target == null)
        {

        }
        else
        {
            Vector3 desiredPosition = target.transform.position + offset;
            transform.position = desiredPosition;
            transform.LookAt(target.transform.position);
        }

        if (Input.GetKey(KeyCode.O))
        {
            target = GameObject.Find("cameraFocus");
        }
    }
}
