using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D collide;
    [SerializeField] private LayerMask jumpableLayer;
    [SerializeField] private AudioSource jumpSFX;
    private enum MovementState { idle, running, jumping, falling }
    public float jumpForce = 12f;
    public float moveSpeed = 5f;
    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.sprite = GetComponent<SpriteRenderer>();
        this.collide = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        Move(dirX);
        setAnimationState(dirX);
        if (Input.GetButtonDown("Jump") && isGrounded())
            Jump();
    }

    private void setAnimationState(float movment)
    {
        MovementState state = MovementState.running;
        if(movment > 0f)        
            sprite.flipX = false;        
        else if (movment < 0f)        
            sprite.flipX = true;        
        else        
            state = MovementState.idle;        

        if(rb.velocity.y > .1f)        
            state = MovementState.jumping;        
        else if(rb.velocity.y < -.1f)        
            state = MovementState.falling;
        
        anim.SetInteger("state", (int)state);
    }

    private void Move(float axis)
    {
        rb.velocity = new Vector2(axis * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        jumpSFX.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.down, .1f, jumpableLayer);
    }
}
