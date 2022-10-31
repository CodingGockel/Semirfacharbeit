using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{ 
    public int health;
    public Transform Respwanpoint;
    public int maxHealth;
    public Rigidbody2D rb;
    public GameObject Player;
    public float RecognizeRange;
    public float speed;
    public Animator animator;
    public Animator waffe;
    public healthbar healthbar;
    public float attackrange;
    public int id;
    public bool canrespawn;
    public IDHandler idhandler;
    public IdHandler2 idhandler2;
    public int help;
    private void Start()
    {
        health = 3;
        maxHealth = 3;
        RecognizeRange = 4f;
        speed = 0.25f;
        attackrange = 3f;
        if (canrespawn)
        {
            transform.position = Respwanpoint.position;
        }
        maxHealth = health;
        healthbar.setMaxHealth(maxHealth);
        rb = this.GetComponent<Rigidbody2D>();
        animator.SetFloat("magnitude", -1);
        Player = GameObject.FindGameObjectWithTag("Player");
        idhandler = GameObject.FindGameObjectWithTag("IdSystem1").GetComponent<IDHandler>();
        idhandler2 = GameObject.FindGameObjectWithTag("IdSystem2").GetComponent<IdHandler2>();
    }

    private void Awake()
    {
        health = maxHealth;
        healthbar.setHealthBar(health);
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        float disttoPlayer = Vector2.Distance(transform.position, Player.transform.position);
        if (health <= 0&&canrespawn)
        {
            transform.position = Respwanpoint.position;
            health = maxHealth;
            animator.SetFloat("magnitude", -1);
            healthbar.setMaxHealth(maxHealth);
        }
        else if (health<=0)
        {
            if (help == 1)
            {
                idhandler.setid(id);
            }
            else
            {
                idhandler2.setid(id);
            }
            healthbar.setHealthBar(maxHealth);
            gameObject.SetActive(false);
            //DestroyImmediate(gameObject);
        }
        else
        {
            if (disttoPlayer <= RecognizeRange&&disttoPlayer>attackrange)
            {
                //moveToPlayer();
            }
            else
            {
                animator.SetFloat("magnitude", -1);
            }

        }

    }
    public void setanim()
    {
        Vector2 direction = Player.transform.position - transform.position;
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
        animator.SetFloat("magnitude", 1);
    }
    public void moveToPlayer()
    {
        Vector2 direction = Player.transform.position - transform.position;
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        //print(direction);
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
        animator.SetFloat("magnitude", direction.magnitude);
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;
        healthbar.setHealthBar(health);
    }
    
    public void Spawn()
    {
        gameObject.SetActive(true);
        health = maxHealth;
    }
}
