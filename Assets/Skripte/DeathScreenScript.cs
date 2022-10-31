using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenScript : MonoBehaviour
{
    public GameObject DeathScreen;
    public GameObject[] DethscreenText;
    private int i;

    public void isdead()
    {
        DeathScreen.SetActive(true);
        i = Random.Range(0, 2);
        print(i);
        DethscreenText[i].SetActive(true);
        Time.timeScale = 0f;
    }

    public void respawn()
    {
        DeathScreen.SetActive(false);
        DethscreenText[i].SetActive(false);
        Time.timeScale = 1f;
    }
}
