using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public bool hasDied;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;
        health = 5;
}

    // Update is called once per frame
    void FixedUpdate()
    {

        if(health == 0)
        {
            Die();
        }

    }

    public static void Die ()
        {
            SceneManager.LoadScene("SampleScene");
        }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.FindWithTag("Enemy"))
        {
            health -= 1;
        }
    }

    public static void Knockback()
    {
          
    }

}
