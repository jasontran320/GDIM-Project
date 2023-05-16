using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem dust;
    private Rigidbody2D rb;
    public float speed;
    [SerializeField]
    private float jumpForce;
    public bool grounded;
    [SerializeField]
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        float animFloat = Mathf.Abs(horizontalInput);
        anim.SetFloat("isMoving", animFloat);

        //Flip character based on movement direction
        if(horizontalInput < -0.01f)
        {
            CreateDust();
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput > 0.01f)
        {
            CreateDust();
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
            anim.SetBool("isJumpp", true);
        }
    }

    private void Jump()
    {
        CreateDust();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        AudioManager.instance.Play("Jump");
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            anim.SetBool("isJumpp", false);
        }
    }
    void CreateDust()
    {
        dust.Play();
    }
}
