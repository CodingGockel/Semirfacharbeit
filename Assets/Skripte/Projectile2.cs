using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    public float lifeTime;
    public float speed;
    public float distance;
    public LayerMask whatIsSolid;
    //public MeshRenderer meshrenderer;
    public int Damage;
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
    private void Update()
    {
        isColliding();

        transform.Translate(Vector2.one * speed * Time.deltaTime);
    }

    public void isColliding()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Player"))
            {
                hitinfo.collider.GetComponent<PlayerMovement>().takeDamage(Damage);
            }
            //meshrenderer.enabled = true;
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
