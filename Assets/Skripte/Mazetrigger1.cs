using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazetrigger1 : MonoBehaviour
{
    public Camera Cam;
    public GameObject player;
    public GameObject respawnpoint;
    public GameObject Wall;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Cam.orthographicSize = 0.8f;
            Wall.SetActive(true);
        }
    }
    public void goOut()
    {
        Cam.orthographicSize = 2.4f;
        player.transform.position = respawnpoint.transform.position;
        Wall.SetActive(false);
    }
}
