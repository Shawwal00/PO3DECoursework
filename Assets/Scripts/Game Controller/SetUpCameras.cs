using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCameras : MonoBehaviour
{

    public Camera ThirdCam;
    public Camera TopDownCam;

    void Start()
    {
        GameObject PlayerCharachter = GameObject.FindGameObjectWithTag("Player");
        ThirdCam.enabled = true;
        TopDownCam.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp("p"))
        {
            ThirdCam.enabled = false;
            TopDownCam.enabled = true;
        }
    }

}
