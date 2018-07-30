using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputControllerTest : MonoBehaviour
{

    static Animator anim;
    public float v;
    public float h;
    public bool hasPU;
    public bool hasRifle;
    public bool hasTimePill;
    public float runTimeCount;
    public float speed = 1.0f;
    public bool reseted = false;
    public float shootRange = 100f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning 0", false);
        anim.SetBool("isWalking", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (hasRifle)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                Debug.Log("KeyCode.Alpha1 pressed");
                Shoot();
                gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.SetActive(true);
                //anim.SetTrigger("flashing");
            }
        }
        v = Input.GetAxis("Vertical") * speed;
        h = Input.GetAxis("Horizontal") * speed;
        hasPU = GetComponent<PowerUpCollector>().hasPU;
        hasRifle = GetComponent<PowerUpCollector>().hasRifle;
        hasTimePill = GetComponent<PowerUpCollector>().hasTimePill;
        transform.Rotate(0, h, 0);
        if (hasPU)
        {
            runTimeCount = 5;
        }
        if (hasRifle)
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            //Debug.Log("hasRifle");
        }
        if (hasTimePill)
        {
            Debug.Log("Time Pill Collected");
        }
        if (v != 0)
        {
            anim.SetBool("isIdle", false);
            if (v > 0)
            {
                if (runTimeCount > 0 && v > 0)
                {
                    //RUNNING
                    anim.SetBool("isRunning 0", true);
                    anim.SetBool("isWalking", false);
                    if (h < 0)
                    {
                        anim.SetBool("runningleft", true);
                        anim.SetBool("runningright", false);
                        anim.SetBool("right", false);
                        anim.SetBool("left", false);
                    }
                    else if (h > 0)
                    {
                        anim.SetBool("runningright", true);
                        anim.SetBool("runningleft", false);
                        anim.SetBool("right", false);
                        anim.SetBool("left", false);
                    } else
                    {
                        anim.SetBool("runningleft", false);
                        anim.SetBool("right", false);
                        anim.SetBool("left", false);
                        anim.SetBool("runningright", false);
                    }
                }
                else if (runTimeCount <= 0 && v > 0)
                {
                    reseted = true;
                    //WALKING
                    anim.SetBool("isRunning 0", false);
                    anim.SetBool("isWalking", true);
                    if (h < 0)
                    {
                        anim.SetBool("left", true);
                        anim.SetBool("right", false);
                        anim.SetBool("runningright", false);
                        anim.SetBool("runningleft", false);
                    }
                    else if (h > 0)
                    {
                        anim.SetBool("right", true);
                        anim.SetBool("left", false);
                        anim.SetBool("runningright", false);
                        anim.SetBool("runningleft", false);
                    } else
                    {
                        anim.SetBool("runningleft", false);
                        anim.SetBool("right", false);
                        anim.SetBool("left", false);
                        anim.SetBool("runningright", false);
                    }
                } else if (v == 0)
                {
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isRunning 0", false);
                }

            }
        } else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning 0", false);
            anim.SetBool("isWalking", false);
        }
        runTimeCount -= Time.time;
    }

    void FixedUpdate()
    {
        anim.SetFloat("walk", v);
        anim.SetFloat("turn", h);
    }

    void Shoot()
    {
        /*if (Vector3.Distance(gameObject.transform.GetChild(3).gameObject.transform.position, GameObject.Find("Bunny1").transform.position) < 20f)
        {
            Debug.Log("Bunny1");
            Destroy(GameObject.Find("Bunny1"));
        } else if (Vector3.Distance(gameObject.transform.GetChild(3).gameObject.transform.position, GameObject.Find("Bunny2").transform.position) < 20f)
        {
            Debug.Log("Bunny2");
            Destroy(GameObject.Find("Bunny2"));
        } else if (Vector3.Distance(gameObject.transform.GetChild(3).gameObject.transform.position, GameObject.Find("Bunny1").transform.position) < 20f)
        {
            Debug.Log("Bunny3");
            Destroy(GameObject.Find("Bunny3"));
        }*/
        Debug.Log("In Shoot()");
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.GetChild(3).gameObject.transform.position, gameObject.transform.GetChild(3).gameObject.transform.forward, out hit, shootRange))
        {
            Debug.Log("hey-------------------" + hit.transform.name);
            //Target target = hit.transform.GetComponent<Target>();
            GameObject enemy = hit.collider.gameObject;
            Debug.Log("collided with" + enemy.tag);
            if (enemy.tag == "enemy")
            {
                Debug.Log("-------------------------------------------");
                Destroy(enemy);
            }
        }
    }
}
