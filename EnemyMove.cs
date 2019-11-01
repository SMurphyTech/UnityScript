using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    public float spawnX, spawnY;

    private void Awake()
    {
        spawnX = transform.position.x;
        spawnY = transform.position.y;

    }


        // Update is called once per frame
        void FixedUpdate()
    {
        transform.Translate(.05f * XMoveDirection, 0, 0);

        if (transform.position.x > spawnX + 2)
        {
            Flip();

        }
        else if(transform.position.x < spawnX - 2)
        {
            Flip();

        }
        /*
        if (hit.collider.tag == "Player")
        {
            Player_Health.Die();
        }
        */
    }

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }else if(XMoveDirection < 0)
        {
            XMoveDirection = 1;
        }
    }

}
