using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(health);

        if (health == 0)
        {
            Die();
        }

    }

    public static void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.FindWithTag("Enemy"))
        {
            health -= 1;
            StartCoroutine("Knockback");
        }

    }

    IEnumerator Knockback()
    {
        GetComponent<Player_Move>().mobile = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(300f * -transform.localScale.x, 0f));
        yield return new WaitForSeconds(.3f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        GetComponent<Player_Move>().mobile = true;
    }
}
