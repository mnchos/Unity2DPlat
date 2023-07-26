using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumpabelground;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState {idle,running,jumping,falling}

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        UpdateAmimationState();


    }
    private void UpdateAmimationState()
    {
        MovementState state;
        if (Input.GetButtonDown("Jump") && IsGrounded() ||(Input.GetButtonDown("Fire1") && IsGrounded()))
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(0, jumpForce);
        }
        
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        
        if (rb.velocity.y> .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y<-.1f)
        {
            state = MovementState.falling;
        }
      
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpabelground);
    }
}
