using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(target.position.x, target.position.y, target.position.z);
        transform.LookAt(targetPos);
    }
}
