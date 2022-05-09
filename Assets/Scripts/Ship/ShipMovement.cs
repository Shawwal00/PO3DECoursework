using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipMovement : MonoBehaviour
{

    private float elapsedTime = 0;
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;
    private float speed = 10;
    public GameObject gameController;
    private CurrentObject currentObject; // Script
    private Animator anim;
    private GameObject ship;

    private void Awake()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
        anim = ship.GetComponent<Animator>();
    }

    private void Start()
    {
       currentObject = gameController.GetComponent<CurrentObject>();
    }

    public void FixedUpdate()
    {
        float turn = Input.GetAxis("Turn");
        elapsedTime += Time.deltaTime;

        if (currentObject.shipEnabled == true)
        {
            anim.SetBool("Active", true);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * (Time.deltaTime * speed));
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * (Time.deltaTime * speed));
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.right * (Time.deltaTime * speed));
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.left * (Time.deltaTime * speed));
            }


            Rotating(turn);
        }
    }

    void Rotating(float mouseXInput)
    {
        //access the avatar's rigidbody
        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        //first check to see if we have rotation data that needs to be applied
        if (mouseXInput != 0)
        {
            //if so we use mouseX value to create a Euler angle which provides rotation in the Y axis
            //which is then turned to a Quaternion
            Quaternion deltaRotation = Quaternion.Euler(0f, mouseXInput * sensitivityX, 0f);

            //and then applied to turn the avatar via the rigidbody
            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }
    }

}

