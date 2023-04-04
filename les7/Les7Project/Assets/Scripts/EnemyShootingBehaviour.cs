using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShootingBehaviour : MonoBehaviour
{
    private Shoot shootScript;
    private TriggerAnimation triggerAnimationScript;
    public Transform target;
    public float shotRange = 10f;
    public float coolDownTime = 1f;

    private bool inCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        shootScript = GetComponentInChildren<Shoot>();
        triggerAnimationScript = GetComponentInChildren<TriggerAnimation>();
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPos);

        Vector3 delta = transform.position - target.position;
        if (delta.magnitude < shotRange && !inCooldown)
        {
            shootScript.Callshot("enemy");
            triggerAnimationScript.CallTrigger();
            inCooldown = true;
            StartCoroutine(Cooldown(coolDownTime));
        }

    }
    private IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        inCooldown = false;
    }
}
