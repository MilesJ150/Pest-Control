using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollector : MonoBehaviour
{
    public bool hasPU;
    public bool hasRifle;
    // Use this for initialization
    void Start()
    {
        hasPU = false;
        hasRifle = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceivePU()
    {
        hasPU = true;
    }

    public void ReceiveRifle()
    {
        hasRifle = true;
    }
}