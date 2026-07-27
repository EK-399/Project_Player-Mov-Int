using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int playerMoney;

    //Take in WASD input
    Vector2 movementInput; //WASD = W (1, 0), A (0, -1)

    //Use that to move the player in that direction.
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    public float moveSpeed = 5;
    public float jumpHeight = 10;

    //Take in SPACE input.ada
    //Apply force upwards.
    //Only be able to jump if touching the ground.

    public bool isGrounded; //Am I touching the ground?

// Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //The code that assigns our rigidbody
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame.
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, rb.linearVelocity.y); //Move the player - Platform
        FlipSprite();
        //rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, movementInput.y * moveSpeed); //Move the player - Topdown
    }

    void FlipSprite()
    {
        //if I am moving RIGHT, I don't want the sprite to be flipped
        if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movementInput.x < 0) //if I am moving LEFT, I want to flip the sprite
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // if
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            //true - do this!
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            //false - do this instead.
            isGrounded = false;
        }
    }

    //FUNCTION TI CONNECT OUR ACTIONS.
    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>(); //This gets the input.
    }

    public void Jump(InputAction.CallbackContext context)
    { 
        if(isGrounded == true) //ONLY IF WE ARE CURRENTLY TOUCHING THE GROUND, WE CAN JUMP!
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight); //Applies velocity UP!
        }
    }
}
