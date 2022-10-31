using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    public int Damage;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
    private void Update()
    {
        isColliding();

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        
    }

    public void isColliding()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Enemy2"))
            {
                hitinfo.collider.GetComponent<Enemy>().TakeDamage(Damage);
                
            }
            else if (hitinfo.collider.CompareTag("Enemy1"))
            {
                hitinfo.collider.GetComponent<Enemy2>().TakeDamage(Damage);
            }
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
