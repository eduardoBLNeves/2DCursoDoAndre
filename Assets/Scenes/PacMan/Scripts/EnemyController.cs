using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;

    Rigidbody2D rb;
    Vector2 direction;

    Vector2 lastPosition;
    float stuckTime = 0f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChooseRandomDirection();
        lastPosition = rb.position;
    }

    void FixedUpdate()
    {
        if (!GameManager.IsRunning) return;

        rb.linearVelocity = direction * moveSpeed;

        float movedDistance = Vector2.Distance(rb.position, lastPosition);

        if (movedDistance < 0.01f)
        {
            stuckTime += Time.fixedDeltaTime;

            if (stuckTime > 0.2f)
            {
                TryOtherDirection();
                stuckTime = 0f;
            }
        }
        else
        {
            stuckTime = 0f;
        }

        lastPosition = rb.position;

        // evento aleatório
        if (Random.value < 0.01f)
        {
            ChooseRandomDirection();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        Vector2 normal = contact.normal;

        if (Mathf.Abs(normal.y) > Mathf.Abs(normal.x))
        {
            direction = Random.value > 0.5f ? Vector2.left : Vector2.right;
        }
        else
        {
            direction = Random.value > 0.5f ? Vector2.up : Vector2.down;
        }
    }

    void TryOtherDirection()
    {
        Vector2[] dirs = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        for (int i = 0; i < dirs.Length; i++)
        {
            Vector2 testDir = dirs[Random.Range(0, dirs.Length)];

            RaycastHit2D hit = Physics2D.Raycast(rb.position, testDir, 0.6f);

            if (!hit.collider)
            {
                direction = testDir;
                return;
            }
        }

        direction = -direction;
    }

    void ChooseRandomDirection()
    {
        Vector2[] dirs = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        direction = dirs[Random.Range(0, dirs.Length)];
    }
}
