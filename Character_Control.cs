using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Control : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float verticalMove = 0f;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
    }

    void FixedUpdate()
    {
        //MoveHorizontally(horizontalMove * Time.fixedDeltaTime);
        //MoveVertically(verticalMove * Time.fixedDeltaTime);
        transform.Translate(horizontalMove, 0, 0);
        transform.Translate(verticalMove, 0, 0);
    }

    //the method that changes the players position on the x axis
    void MoveHorizontally(float move)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
        m_Rigidbody2D.velocity = targetVelocity;

        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    void MoveVertically(float move)
    {
        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, move * 10f);

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
