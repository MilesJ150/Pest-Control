using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRespawn : MonoBehaviour {

    private void OnTriggerEnter(Collider c)
    {
        CharacterHitByEnemy script = c.attachedRigidbody.gameObject.GetComponent<CharacterHitByEnemy>();
        script.SetSpawnPos(this.transform);
    }
}
