using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask groundMask;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public float speed = 10f;
    public Vector2 dir;
    public float jumpForce = 10f;

    void Update()
    {
        dir = new Vector2(Input.GetAxis("Horizontal"), 0);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        movements(dir);
    }

    public void movements(Vector2 move)
    {
        if (move.x > 0)
            transform.localScale = new Vector3(2, 2, 2);
        else if (move.x < 0)
            transform.localScale = new Vector3(-2, 2, 2);
        rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 2f, groundMask);
        return raycastHit.collider != null;
    }
}
