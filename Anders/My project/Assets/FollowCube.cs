using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowCube : MonoBehaviour
{
    public GameObject Follow;
    [SerializeField] private int speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3((Follow.transform.position.x - transform.position.x), 0, 0);
    }
}
