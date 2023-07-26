using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float playerJumpHeight;
    public float playerGravity;
    public LayerMask groundMask;

    private Rigidbody2D rb;

    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        //initiate the player rigidbody
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player is standing on ground
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.2f, groundMask))
        {
            
            //reset gravity when player lands
            if (rb.velocity.y <= 0)
            {
                rb.gravityScale = 0f;
                isGrounded = true;
            }
        } else
        {
            rb.gravityScale = playerGravity;
        }

        //get player right/left input and store direction as -1 or 1
        float direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * playerSpeed, rb.velocity.y);

        if (direction != 0) rb.gravityScale = playerGravity;

        //get up input and check if the player is touching the ground
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.gravityScale = playerGravity;
            rb.AddForce(transform.up * playerJumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
