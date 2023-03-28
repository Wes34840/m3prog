using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ob = Instantiate(prefab);
            ob.transform.position = transform.position;
            ob.transform.rotation = transform.rotation;
            Destroy(ob, 3f);
        }
    }
}
