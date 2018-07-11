using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            PowerUpCollector pc = c.attachedRigidbody.gameObject.GetComponent<PowerUpCollector>();
            if (pc != null)
            {
                Destroy(this.gameObject);
                pc.ReceivePU();
            }
        }
        /*if (c.attachedRigidbody != null && c.GetComponent<PowerUpCollector>() != null)
        {
            PowerUpCollector puc = c.attachedRigidbody.gameObject.GetComponent<PowerUpCollector>();
            //Destroy(this.gameObject);
            puc.ReceivePU();
        }*/
    }
}
