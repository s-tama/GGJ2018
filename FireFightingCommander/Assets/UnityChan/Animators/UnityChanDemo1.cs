using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnityChanDemo1 : MonoBehaviour
{

    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * 0.01f;
            animator.SetBool("is_running", true);
        }
        else
        {
            animator.SetBool("is_running", false);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 10, 0);
            transform.position += transform.forward * 0.01f;
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -10, 0);
            transform.position += transform.forward * 0.01f;
        }
    }
}

