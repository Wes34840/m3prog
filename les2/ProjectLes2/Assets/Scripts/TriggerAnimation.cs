using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = GetComponent <GetAxisRaw("Horizontal")>();

        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            m_Animator.SetTrigger("Reaction");
        }
    }
}
