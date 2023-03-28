using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask JumpableGround;
    [SerializeField] private GameObject Spawnpoint;

    [SerializeField] private float MoveSpeed = 8f;
    [SerializeField] private float JumpForce = 10f;
    private float dirX;
    private float dirY;
    private float timer = 2f;

    private Vector3 SpawnPointLocation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = rb.GetComponent<BoxCollider2D>();
        SpawnPointLocation = Spawnpoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX * MoveSpeed, rb.velocity.y);

        if (dirY > 0 && IsGrounded() == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce);

            UpdateSpawnPoint();
        }
        
        if (rb.position.y < -6)
        {
            Respawn();
        }

        if (rb.velocity.y == 0f)
        {
            SpawnMoveTimer();
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Respawn();
        }
    }
    private void Respawn()
    {
        rb.velocity = Vector2.zero;
        transform.position = SpawnPointLocation;
    }
    private void UpdateSpawnPoint()
    {
        Spawnpoint.transform.position = transform.position; // puts spawnpoint object at player position
        SpawnPointLocation = Spawnpoint.transform.position; // puts spawnpoint Vector3 value at spawnpoint object position
    }
    private void SpawnMoveTimer()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            UpdateSpawnPoint();
            timer = 2f;
        }
    }
}
