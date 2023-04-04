using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnHit : MonoBehaviour
{

    public string targetTag;
    public GameObject effect;
    private AudioSource audioSource;
    private Heart HeartScript;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == targetTag)
        {
            handleHit(coll.gameObject);
        }

    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == targetTag)
        {
            GameObject expl = Instantiate(effect);
            expl.transform.position = coll.transform.position;
            Destroy(expl, 2f);
            Destroy(coll.gameObject, 0.1f);
            audioSource.Play();
        }

    }
    private void handleHit(GameObject obj)
    {
        if(obj.tag == targetTag)
        {
            GameObject expl = Instantiate(effect);
            expl.transform.position = obj.transform.position;
            Destroy(expl, 2f);
            if(targetTag == "player")
            {
                if (HeartScript == null)
                {
                    HeartScript = FindObjectOfType<Heart>();
                }
                HeartScript.lives--;
                if (HeartScript.Lives == 0)
                {
                    Destroy(obj, 0.1f);
                }
            }
            else 
            {
                Destroy(obj, 0.1f);
            }
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
