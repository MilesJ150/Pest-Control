using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{

    public Camera person;
    public Camera drone;
    bool whichCam;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        person.GetComponent<Camera>().enabled = true;
        drone.GetComponent<Camera>().enabled = false;
        whichCam = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (whichCam)
            {
                person.GetComponent<Camera>().enabled = false;
                drone.GetComponent<Camera>().enabled = true;
                whichCam = false;
                //player.GetComponent<CharacterInputController>().enabled = false;
                //player.GetComponent<Animator>().enabled = false;
                player.GetComponent<CharacterInputControllerTest>().speed = 0.0f;
            }
            else
            {
                person.GetComponent<Camera>().enabled = true;
                drone.GetComponent<Camera>().enabled = false;
                whichCam = true;
                //player.GetComponent<CharacterInputController>().enabled = true;
                //player.GetComponent<Animator>().enabled = true;
                player.GetComponent<CharacterInputControllerTest>().speed = 1.0f;
            }

        }
    }
}
