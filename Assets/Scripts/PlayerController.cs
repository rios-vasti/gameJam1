using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private float speed = 5f;
    private bool isRight = true;
    private float moveX;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        if (rb.velocity.x > 0.05 && !isRight)
        {
            isRight = true;
            sprite.flipX = false;
        }
        else if (rb.velocity.x < -0.05 && isRight)
        {
            isRight = false;
            sprite.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        animator.SetFloat("xVelo", Mathf.Abs(rb.velocity.x));
    }
}