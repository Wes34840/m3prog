using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementXY : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 1f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Time.deltaTime * MoveSpeed * Input.GetAxis("Horizontal");
        float moveZ = Time.deltaTime * MoveSpeed * Input.GetAxis("Vertical");
        rb.velocity = new Vector3(moveX, 0, moveZ);
    }
}
