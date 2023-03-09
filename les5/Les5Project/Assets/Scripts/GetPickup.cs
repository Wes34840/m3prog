using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPickup : MonoBehaviour
{

    private Renderer rend;
    private AudioSource source;
    private ParticleSystem particle;
    private KeepScore scoreScript;

    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<Renderer>();     
        source = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        particle.Stop();

      //  scoreScript = FindAnyObjectByType<KeepScore>();

        scoreScript = FindObjectOfType<KeepScore>();

    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            rend.enabled = false;
            GameObject.Destroy(gameObject, 0.5f);

            source.Play();
            particle.Play();
            scoreScript.AddScore(1);
        }
    }
}
