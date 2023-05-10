using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float jumpHeight;

    bool facing;
    bool grounded;

    Rigidbody2D myBody;
    Animator myAnim;

    

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facing = true;
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        myAnim.SetFloat("Speed", Mathf.Abs(move));

        myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);

        if(move > 0 && !facing)
        {
            flip();
        } else if(move < 0 && facing)
        {
            flip();
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
                myAnim.SetBool("Jump", true);
            }
        }
        if (grounded)
        {
            myAnim.SetBool("Jump", false);
        }
    } 

    void flip()
    {
        facing = !facing;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D orther)
    {
        if(orther.gameObject.tag == "grounded")
        {
            grounded = true;
        }
    }
}
