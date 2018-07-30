using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollector : MonoBehaviour
{
    public bool hasPU;
    // Use this for initialization
    void Start()
    {
        hasPU = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceivePU()
    {
        hasPU = true;
    }
}