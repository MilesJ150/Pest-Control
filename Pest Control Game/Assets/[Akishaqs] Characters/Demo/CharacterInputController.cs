using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    static Animator anim;
    private Vector3 offset;

    public float speed = 1.0f;
    public float rotationSpeed = 75.0f;
    public float runSpeed = 3.0f;
    public float walkSpeed = 1.0f;
    public int count = 0;
    public bool isColliding = false;

    public float timeSaved;
    public bool hasPU;

    void Start()
    {
        anim = GetComponent<Animator>();
        hasPU = GetComponent<PowerUpCollector>().hasPU;
    }

    void OnCollisionEnter (Collider target)
    {
        count += 1;
        if (target.gameObject.tag.Equals("wall") == true)
        {
            isColliding = true; 
        }
        if (target.gameObject.tag.Equals("PU") == true)
        {
            hasPU = GetComponent<PowerUpCollector>().hasPU;
            //Destroy(target.gameObject);
            timeSaved = GetComponent<PowerUp>().savedTime;
        }

    }
    void Update()
    {
        float translation = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");
        //translation += Time.deltaTime;
        //rotation += Time.deltaTime;
        //transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (!isColliding)
        {
            if (Input.GetKey(KeyCode.LeftShift) && timeSaved >= 0)
            {
                if (translation != 0)
                {
                    /*anim.SetBool("isRunning", true);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isIdle", false);
                    speed = runSpeed;*/
                    if (rotation == 0)
                    {
                        anim.Play("HumanoidRun");
                    }
                    else if (rotation < 0)
                    {
                        anim.Play("HumanoidRunLeft");
                    }
                    else if (rotation > 0)
                    {
                        anim.Play("HumanoidRunRight");
                    }
                }
                if (translation == 0)
                {
                    anim.Play("HumanoidIdle");
                }
            }
            else
            {
                if (translation != 0)
                {
                    /*
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isIdle", false);
                    speed = walkSpeed;
                    */
                    if (rotation == 0)
                    {
                        anim.Play("HumanoidWalk");
                    }
                    else if (rotation < 0)
                    {
                        anim.Play("HumanoidWalkLeft");
                    }
                    else if (rotation > 0)
                    {
                        anim.Play("HumanoidWalkRight");
                    }
                }
                if (translation == 0)
                {
                    /*anim.SetBool("isRunning", false);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isIdle", true);*/
                    anim.Play("HumanoidIdle");
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                anim.Play("HumanoidIdleJumpUp");
                anim.SetTrigger("isJumping");
            }
        }
    }
    
}
