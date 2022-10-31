using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private GameObject player;
    private PlayerMovement restorehealth;
    public int health;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        restorehealth = player.GetComponent<PlayerMovement>();

    }

    public void spawnDroppedItem(float offset)
    {
        Vector2 playerpos = new Vector2(player.transform.position.x+offset, player.transform.position.y+0.5f );
        Instantiate(item, playerpos, Quaternion.identity);
    }

    public void healPlayer(int health) 
    {
        restorehealth.heal(health);
        Destroy(gameObject);
    }
}
