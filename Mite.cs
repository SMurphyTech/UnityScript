using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mite : Enemy_Base
{
    public int directionY = 1;
    public int directionX = 1;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeedY = 10f;
        StartCoroutine("BackForth");
        StartCoroutine("AttackLoop");
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        trackPlayer();

        //transform.Translate(moveSpeedX * directionX, moveSpeedY * directionY, 0);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector2(moveSpeedX * directionX, moveSpeedY * directionY), ref velocity, 0.05f);

        if (!windingup)
        {
            Flip();
            Backaway();
        }
        
    }

    //the monster bounces vertically up and down
    IEnumerator BackForth()
    {
        moveSpeedY = 5f;
        while (windingup == false)
        {
            directionY = -directionY;
            yield return new WaitForSeconds(1f);
        }
      
    }

    //the monster always faces the player
    void Flip()
    {
        if (playerX > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // the monster backs away faster when the player approaches
    void Backaway()
    {
        if (playerX - 3f > transform.position.x || playerX + 3f < transform.position.x)
        {
            moveSpeedX = 1f;
        }
        else if (transform.position.x < playerX)
        {
            moveSpeedX = 5f;
            directionX = -1;
        }
        else if (transform.position.x > playerX)
        {
            moveSpeedX = 5f;
            directionX = 1;
        }
    }

    //when the monster enters the sword hitbox, it gets knockbacked for .3 seconds
    IEnumerator Knockback()
    {
        moveSpeedY = 0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(300f * -transform.localScale.x, 0f));
        yield return new WaitForSeconds(.3f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        moveSpeedY = 5f;
    }

    IEnumerator AttackLoop()
    {
        //the loop that triggers the charge attack every 8 seconds
        while (true)
        {
            //every 8 seconds...
            yield return new WaitForSeconds(8f);
            //... when the monster is lined up with the player horizotally
            yield return new WaitUntil(() => !(playerY - 1f > transform.position.y || playerY + 1f < transform.position.y));

            windingup = true;

            //the monster stops going up and down and wind's up for a charge
            moveSpeedY = 0f;
            StopCoroutine("BackForth");
            StartCoroutine("Windup");
            
        }
    }

    //the monster winds up and charges toward you
    IEnumerator Windup()
    {
        //monster reverses
        moveSpeedX = 3f;
        Debug.Log("1");
        yield return new WaitForSeconds(.5f);
        //suspense
        moveSpeedX = 0f;
        Debug.Log("2");
        yield return new WaitForSeconds(.5f);
        //monster charges forward
        directionX = -directionX;
        moveSpeedX = 20f;
        Debug.Log("3");
        yield return new WaitForSeconds(.8f);
        //skids to a stop
        moveSpeedX = 0f;
        Debug.Log("4");
        yield return new WaitForSeconds(.5f);
        windingup = false;
        StartCoroutine("BackForth");       
    }
}
