using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlatformerController : MonoBehaviour {
    [HideInInspector]
    public bool facingRight = true;

    [HideInInspector]
    public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;

    private bool grounded = false;
    //private Animator anim;
    private Rigidbody rb;


    // Use this for initialization
    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(transform.position, Vector3.down);
        grounded = Physics.Raycast(ray, 0.1f, LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        if (Input.GetButtonDown("RotateLeft"))
        {
            Rotate(-1);
        }

        if (Input.GetButtonDown("RotateRight"))
        {
            Rotate(1);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb.velocity.x < maxSpeed)
            rb.AddForce(Vector3.right * h * moveForce);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            //anim.SetTrigger("Jump");
            rb.AddForce(new Vector3(0f, jumpForce));
            jump = false;
        }
    }

    void Rotate(int sign)
    {
        transform.Rotate(Vector3.up * 90 * sign);
        //rb.AddTorque();
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
