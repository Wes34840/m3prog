using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 250f;
    [SerializeField] private float Jumpforce = 400f;

    private float moveX;
    private float moveZ;
    private bool isGrounded;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Time.deltaTime * MoveSpeed * Input.GetAxisRaw("Horizontal");
        moveZ = Time.deltaTime * MoveSpeed * Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(moveX, rb.velocity.y, moveZ);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.AddForce(transform.up * Jumpforce);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }
}
