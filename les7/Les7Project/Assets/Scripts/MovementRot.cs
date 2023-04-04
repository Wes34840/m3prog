using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRot : MonoBehaviour
{
    [SerializeField] private float speed = 400f;
    [SerializeField] private float rotSpeed = 100f;
    [SerializeField] private float Jumpforce = 400f;
    private bool isGrounded;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Time.deltaTime * speed * Input.GetAxis("Vertical");

        Vector3 lastVel = rb.velocity;
        Vector3 newVel = rb.transform.forward * move;
        newVel.y = lastVel.y;
        rb.velocity = newVel;

        float rot = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rb.transform.Rotate(new Vector3(0, rot, 0));

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.AddForce(transform.up * Jumpforce);
            isGrounded = false;
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
