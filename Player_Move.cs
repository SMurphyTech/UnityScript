 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float moveSpeed = .3f;
    public float moveX, moveY;
    private bool m_FacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveY = Input.GetAxisRaw("Vertical") * moveSpeed;

        transform.Translate(moveX, moveY, 0);

        if (moveX > 0f && !m_FacingRight)
        {
            // ... flip the player.
            Debug.Log("flip");
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (moveX < 0f && m_FacingRight)
        {
            // ... flip the player.
            Flip();
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
