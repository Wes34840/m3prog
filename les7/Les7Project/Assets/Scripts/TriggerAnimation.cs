using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public string triggerName;
    public float delay = 0f;
    public float resetTime = 0.45f;
    public KeyCode triggerKey = KeyCode.None;
    public AudioSource audioSource;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            CallTrigger();
        }
        
    }
    public void CallTrigger()
    {
        StartCoroutine(AwaitDelay(delay));
        StartCoroutine(AwaitReset(resetTime));
    }
    private IEnumerator AwaitDelay(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetTrigger(triggerName);
        if (audioSource != null)
        {
            audioSource.Play();
        }   
    }
    private IEnumerator AwaitReset(float time)
    {
        yield return new WaitForSeconds(time);
        animator.ResetTrigger(triggerName);
    }
}
