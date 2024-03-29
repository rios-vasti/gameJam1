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
    private float moveY;
    private GameManager gameManager; 
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
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
        moveY = Input.GetAxis("Vertical");
 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("LightBeam"))
        {
            Debug.Log("Hit Spike");
            //call the Game Manager to restart the level intead of the player getting destroyed
            gameManager.restartLevel();

        }
        if (collision.gameObject.CompareTag("Exit"))
        {
            gameManager.levelPassed();
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * speed, moveY * speed);
        //Debug.Log("xVelo: " + rb.velocity.x);
        animator.SetFloat("xVelo", Mathf.Abs(rb.velocity.x));
    }
}
