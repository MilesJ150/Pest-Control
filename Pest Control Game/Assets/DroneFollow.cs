using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFollow : MonoBehaviour {

    public GameObject player;
	
	void Update () {
        transform.position = player.transform.position + Vector3.up * 30f;
        transform.LookAt(player.transform);
	}
}
