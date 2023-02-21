using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            anim.SetTrigger("Running");

            anim.ResetTrigger("Idle");
            anim.ResetTrigger("RunningR");
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetTrigger("RunningR");

            anim.ResetTrigger("Idle");
            anim.ResetTrigger("Running");
        }
        else
        {
            anim.SetTrigger("Idle");
            anim.ResetTrigger("Running");
            anim.ResetTrigger("RunningR");
        }
    }
}
