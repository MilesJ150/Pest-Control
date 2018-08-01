using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerUp : MonoBehaviour {


    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            PowerUpCollector pc = c.attachedRigidbody.gameObject.GetComponent<PowerUpCollector>();
            if (pc != null)
            {
                Debug.Log("TimePowerUp");
                Destroy(this.gameObject);
                pc.ReceiveTimePill();
            }
        }
    }
}
