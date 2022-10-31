using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public GameObject key;
    public bool open;
    
    void Start()
    {
        open = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&(!open))
        {
            Vector2 pos = new Vector2(transform.position.x,transform.position.y-0.5f);
            Instantiate(key,pos,Quaternion.identity);
            open = true;
            animator.SetBool("open", open);
        }
    }

}
