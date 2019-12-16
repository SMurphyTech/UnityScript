 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public bool mobile = true;
    public float moveSpeed = 10f;
    public float moveX, moveY;
    private bool m_FacingRight = true;
    public float directionX;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            directionX = Input.GetAxisRaw("Horizontal");
        }

        if (mobile == true)
        {
            moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
            moveY = Input.GetAxisRaw("Vertical") * moveSpeed;

            //moveX = moveX * Time.fixedDeltaTime;
            //moveY = moveY * Time.fixedDeltaTime;

            //transform.Translate(moveX, moveY, 0);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector2(moveX, moveY), ref velocity, 0.05f);

            if (moveX > 0f && !m_FacingRight)
            {
                // ... flip the player.
                
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (moveX < 0f && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        else
        {
            moveX = 0;
            moveY = 0;
            rb.velocity = new Vector2(0f, 0f);
        }
    }

    void Flip()
    {
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
