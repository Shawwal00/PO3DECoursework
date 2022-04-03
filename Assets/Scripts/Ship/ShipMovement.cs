using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipMovement : MonoBehaviour
{

    private float elapsedTime = 0;
    private Animator anim;
    private HashIDs hash;

    public void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");

        elapsedTime += Time.deltaTime;

        MovementManager(v);
    }

    void MovementManager(float vertical)
    {

        if (vertical > 0)
        {
         
        }

        else  if (vertical < 0)
        {
            Rigidbody ourBody = this.GetComponent<Rigidbody>();
            float movement = Mathf.Lerp(0f, -0.02f, elapsedTime);
            Vector3 moveBack = new Vector3(0.0f, 0.0f, movement);
            moveBack = ourBody.transform.TransformDirection(moveBack);
            ourBody.transform.position += moveBack;
        }
    }

}

