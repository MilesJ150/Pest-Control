using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerUp : MonoBehaviour {

    float collectedTime = 0f;
    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            PowerUpCollector pc = c.attachedRigidbody.gameObject.GetComponent<PowerUpCollector>();
            if (pc != null)
            {
                Destroy(this.gameObject);
                this.gameObject.SetActive(false);
                pc.ReceiveTimePill();
                collectedTime = 30f;
            }
        }
    }
}
