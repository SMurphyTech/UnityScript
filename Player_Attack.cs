using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{    
    public bool attacking = false;
    private float attackPeriod = .3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
        if (Input.GetButtonDown("Attack"))
        {
            GetComponent<Player_Move>().mobile = false;
            attacking = true;
            Attack();
            //Debug.Log("attack");
        }

        if(attacking == true)
        {
            attackPeriod -= Time.deltaTime;
            if(attackPeriod < 0.1f)
            {
                GetComponent<Player_Move>().mobile = true;
                attacking = false;
                attackPeriod = .3f;
            }
        }
    }

    void Attack()
    {

    }

    public bool getAttacking()
    {
        return attacking;
    }
}
