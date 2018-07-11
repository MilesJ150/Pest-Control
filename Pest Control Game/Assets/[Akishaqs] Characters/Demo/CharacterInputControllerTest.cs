using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputControllerTest : MonoBehaviour {

    static Animator anim;
    public float v;
    public float h;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        if (v > 0)
        {
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
        }
        if (h < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetTrigger("runningleft");
            } else
            {
                anim.SetTrigger("left");
            }
        }
        if (h > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetTrigger("runningright");
            } else
            {
                anim.SetTrigger("right");
            }
        }

	}

    void FixedUpdate()
    {
        anim.SetFloat("walk", v);
        anim.SetFloat("turn", h);
    }
}
