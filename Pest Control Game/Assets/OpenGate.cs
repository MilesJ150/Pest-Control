using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{

    public GameObject gate;

    void Update()
    {

    }
    private void OnTriggerEnter(Collider c)
    {
        Destroy(gate);
    }
}