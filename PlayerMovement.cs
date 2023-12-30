using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    BoxCollider2D coll;

    [SerializeField] private LayerMask jumpable_ground;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f ;
    private float dirX;


    private enum Movementstate {idle, runnnig, jumping, falling }
    private Movementstate state = Movementstate.idle;
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
       
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("hop") && groundCheck())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }
        UpdateAnimation();
    }
        private void UpdateAnimation() {

        Movementstate state;

        if(dirX > 0){
           state=Movementstate.runnnig;
            sprite.flipX = false;
        }
        else if (dirX < 0) {
            state =Movementstate.runnnig;
            sprite.flipX = true;
        }
        else{
            state = Movementstate.idle;
        }


        if (rb.velocity.y > .1f)
        {
            state = Movementstate.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = Movementstate.falling;
        }

        anim.SetInteger("state", (int)state);
    }
   private bool groundCheck()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpable_ground);
    }
}
