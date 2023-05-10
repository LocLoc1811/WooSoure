using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int Damage;

    public float TimeBtwFire = 0.2f;

    private float timeBtwFire;


    void FixedUpdate()
    {
        timeBtwFire -= Time.deltaTime;

        /* if (Input.GetKey(KeyCode.K) && timeBtwFire < 0)
        {
            myAnim.SetBool("Attack", true);
        }
        else
        {
            myAnim.SetBool("Attack", false);
        } */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int damage = Damage;
            collision.GetComponent<EnemyHealth>().addDamage(damage);
            //collision.GetComponent<EnemyController>().TakeDamEffect(damage);
            //Destroy(gameObject);
        }
    }
}
