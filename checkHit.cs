using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHit : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Player_Attack>().attacking == true)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().transform.position = player.transform.position + new Vector3(0.27f + player.transform.localScale.x * .8f, 0, 0);
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.FindWithTag("Enemy"))
        {
            Debug.Log("hit!"); 
        }
    }
    */
}
