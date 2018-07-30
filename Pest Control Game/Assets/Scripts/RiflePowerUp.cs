using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePowerUp : MonoBehaviour {

    public float savedTime;

    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            PowerUpCollector pc = c.attachedRigidbody.gameObject.GetComponent<PowerUpCollector>();
            if (pc != null)
            {
                Debug.Log("RiflePowerUP");
                Destroy(this.gameObject);
                pc.ReceiveRifle();
                savedTime = Time.time;
            }
        }
    }

}
