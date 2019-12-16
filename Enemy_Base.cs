using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Base : MonoBehaviour
{
    public bool windingup = false;
    public float moveSpeedX, moveSpeedY;
    public float playerX, playerY;
    public GameObject player;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void trackPlayer()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == GameObject.FindWithTag("PlayerAttack"))
        {
            if (windingup != true)
            {
                StartCoroutine("Knockback");
            }
        }
    }
}
