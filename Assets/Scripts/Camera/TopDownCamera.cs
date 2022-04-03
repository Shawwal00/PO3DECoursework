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
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        transform.position = desiredPosition;
        transform.LookAt(target.transform.position);
    }
}
