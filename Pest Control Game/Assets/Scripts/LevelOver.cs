using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOver : MonoBehaviour {

    public bool ended = false;
    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            SceneManager.LoadScene("Start");
            ended = true;
        }
    }
}
