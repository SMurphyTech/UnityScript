using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public bool attacking = false;
    public GameObject swordBox;
    private GameObject instanceOfSword;

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
            StartCoroutine("Attack");
        }
    }

    IEnumerator Attack()
    {
        instanceOfSword = Instantiate(swordBox, new Vector3(transform.position.x + 1 * GetComponent<Player_Move>().directionX, transform.position.y, 0), Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        Destroy(instanceOfSword);
        GetComponent<Player_Move>().mobile = true;
        attacking = false;
    }
}
