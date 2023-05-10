using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject restartMenu;

    Animator MyAnim;

    public float maxHealth;
    float currentHealth;

    public float Time;

    //private float safeTime;
    //public float safeTimeDuration = 0f;

    //public Slider playerHealthSlider;

    private void Start()
    {
        currentHealth = maxHealth;

        //playerHealthSlider.maxValue = maxHealth;
       // playerHealthSlider.value = maxHealth;

        MyAnim = GetComponent<Animator>();
    }

    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        
        currentHealth -= damage;

       // playerHealthSlider.value = currentHealth;

        if (currentHealth <= 0)
            makeDead();

           
        }
    

    void makeDead()
    {
        MyAnim.SetBool("Dead", true);
        //gameObject.SetActive(false);
        Destroy(gameObject, Time);
       
        restartMenu.SetActive(true);
    }

    /*//hoi mau bang poision
    public void addHealth(float HealthAmount)
    {
        currentHealth += HealthAmount;
        if (currentHealth >= maxHealth) 
            currentHealth = maxHealth;
       // playerHealthSlider.value = currentHealth;
    } */
}
