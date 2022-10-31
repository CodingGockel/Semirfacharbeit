using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float timebtwshots;
    public float starttimebtwshots;
    public float attackRange;
    public GameObject projectile2;
    public Transform shotpoint;
    //public MeshRenderer meshrenderer;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackRange = 3f;
        starttimebtwshots = 4;
        timebtwshots = 4;

    }
    void Update()
    {
        float disttoPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (disttoPlayer<=attackRange&&timebtwshots<=0)
        {
            Instantiate(projectile2, shotpoint.position, transform.rotation);
            //meshrenderer.enabled = false;
            timebtwshots = starttimebtwshots;
        }
        else
        {
            timebtwshots -= Time.deltaTime;
            setRot();
        }
    }
    public void setRot()
    {
        Vector3 difference = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ+offset);
    }
}

