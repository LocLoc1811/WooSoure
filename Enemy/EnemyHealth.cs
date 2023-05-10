using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    float curentHealth;

    //public Slider EnemyHealthSlider;

    public bool drop;
    public GameObject theDrop;

    Animator EnemyAnim;

    public float Time;

    public float pushBackForce;

    void Start()
    {
        curentHealth = maxHealth;

        //EnemyHealthSlider.maxValue = maxHealth;
        //EnemyHealthSlider.value = maxHealth;

        EnemyAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        //EnemyHealthSlider.gameObject.SetActive(true);
        curentHealth -= damage;

        //EnemyHealthSlider.value = curentHealth;

        if (curentHealth <= 0)
            makeDead();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.GetComponentInParent<Rigidbody2D> ();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }

    void makeDead()
    {
        EnemyAnim.SetBool("Dead", true);

        if (drop)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }

        Destroy(gameObject, Time);
    }
}

   