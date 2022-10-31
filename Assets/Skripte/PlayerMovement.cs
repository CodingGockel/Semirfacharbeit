using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public healthbar healthbar;
    public int maxhealth;
    public int health;
    public Transform respawnPoint;
    public float speed;
    private Inv inventory;
    public DeathScreenScript deathScreenScript;

    private void Start()
    {
        transform.position = respawnPoint.position;
        health = maxhealth;
        healthbar.setMaxHealth(maxhealth);
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inv>();
    }
    void FixedUpdate()
    {
        if (health<=0)
        {
            deathScreenScript.isdead();
            inventory.dropAllItems();
            transform.position = respawnPoint.position;
            health = maxhealth;
            healthbar.setMaxHealth(maxhealth);
            animator.SetFloat("Magnitude", -1);
        }
        else
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical",movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            //transform.position = transform.position + movement * Time.deltaTime;
            //rb.velocity = new Vector2(movement.x, movement.y);
            rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
        }
        
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        healthbar.setHealthBar(health);
    }
    public void heal(int heal)
    {
        if (health<=maxhealth-2)
        {
            health += heal;
            healthbar.setHealthBar(health);
        }
        else if (health<=maxhealth-1)
        {
            health += heal-1;
            healthbar.setHealthBar(health);
        }
    }
    public void healfull()
    {
        health = maxhealth;
        healthbar.setHealthBar(health);
    }
}
