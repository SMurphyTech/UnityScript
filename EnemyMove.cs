using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject attack_box;
    public bool knockbacking;
    private float knockback_period = 0.5f;
    public float EnemySpeed;
    public int XMoveDirection;
    public float spawnX, spawnY;

    private void Awake()
    {
        attack_box = GameObject.FindWithTag("s_hitbox");
        spawnX = transform.position.x;
        spawnY = transform.position.y;
        EnemySpeed = .05f;
        
    }


        // Update is called once per frame
        void FixedUpdate()
    {
        transform.Translate(EnemySpeed * XMoveDirection, 0, 0);

        if (knockbacking == false)
        {
            if (transform.position.x > spawnX + 2)
            {
                Flip();

            }
            else if (transform.position.x < spawnX - 2)
            {
                Flip();

            }
        }

        if (knockbacking == true)
        {
            knockback_period -= Time.deltaTime;
            if (knockback_period < 0.1f)
            {
                knockbacking = false;
                knockback_period = 0.5f;
                EnemySpeed = 0.05f;
                spawnX = transform.position.x;
                spawnY = transform.position.y;
            }
        }
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.FindWithTag("s_hitbox"))
        {
            if (knockbacking == false)
            {
                //Physics2D.IgnoreCollision(attack_box.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>(), false);
                Debug.Log("hit!");
                GetComponent<Enemy_Health>().health -= 1;
                Knockback();
                attack_box.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                //Physics2D.IgnoreCollision(attack_box.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>());
            }
        }

        if (collision.gameObject.name == "Tilemap_Walls" || collision.gameObject == GameObject.FindWithTag("Player"))
        {
            XMoveDirection = -XMoveDirection;
        }
    }

    void Knockback()
    {
        knockbacking = true;
        EnemySpeed = .15f;
        XMoveDirection = -XMoveDirection;
    }

}
