using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public int playerMoney;

    //Take in WASD input
    Vector2 movementInput; //WASD = W (1, 0), A (0, -1)

    //Use that to move the player in that direction.
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public float moveSpeed = 5;
    public float jumpHeight = 10;

    //Take in SPACE input.ada
    //Apply force upwards.
    //Only be able to jump if touching the ground.

    public bool isGrounded; //Am I touching the ground?
    public LayerMask groundlayer; //WHAT IS GROUND?

// Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //The code that assigns our rigidbody
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame.
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, rb.linearVelocity.y); //Move the player - Platform
        FlipSprite();

        Debug.DrawRay(transform.position, Vector2.down * 1, Color.purple); //draws the line
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1, groundlayer);

        UpdateAnimator();

        //rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, movementInput.y * moveSpeed); //Move the player - Topdown
    }

    void UpdateAnimator()
    {
        if(movementInput.x == 0)
        {
            //Player stays still
            anim.SetBool("Moving", false);
        }
        else
        {
            //Player is moving
            anim.SetBool("Moving", true);
        }
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

    public bool playerInteracting; //Is E key being pressed?
    public void Interact(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            playerInteracting = true;
        }
        else if (context.canceled) //HAVE I LET E GO?
        {
            playerInteracting = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    { 
        if(isGrounded == true) //ONLY IF WE ARE CURRENTLY TOUCHING THE GROUND, WE CAN JUMP!
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight); //Applies velocity UP!
        }
    }
}
