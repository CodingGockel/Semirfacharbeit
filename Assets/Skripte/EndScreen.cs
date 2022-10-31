using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject endscreen;
    public Inv inventory;
    void Update()
    {
        if (inventory.allkeys())
        {
            endscreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
