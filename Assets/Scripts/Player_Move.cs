using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 17;
    public float jumpForce = 1000f;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spRenderer;
    private bool isGround;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.spRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (x > 0)
        {
            spRenderer.flipX = false;
        }
        else if (x < 0)
        {
            spRenderer.flipX = true;
        }

        rb2d.velocity = new Vector2(x * speed, rb2d.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetButtonDown("Jump") & isGround)
        {
            anim.SetBool("isJump",true);
            rb2d.AddForce(Vector2.up * jumpForce);
        }

        if (isGround)
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isFall", false);
        }

        float velX = rb2d.velocity.x;
        float velY = rb2d.velocity.y;

        if (Mathf.Abs(velX) > 15)
        {

            if (velX > 15.0f)
            {
                rb2d.velocity = new Vector2(15.0f, velY);
            }
            if (velX < -15.0f)
            {
                rb2d.velocity = new Vector2(-15.0f, velY);
            }
        }
    }
    private void FixedUpdate()
    {
        isGround = false;
        Vector2 groundPos =
            new Vector2(
                transform.position.x,
                transform.position.y

                );
        Vector2 groundArea = new Vector2(0.5f, 0.5f);
        isGround =
            Physics2D.OverlapArea(
                groundPos + groundArea,
                groundPos - groundArea,
                groundLayer
                );
    }
}
