using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTrigger2 : MonoBehaviour
{
    public Mazetrigger1 mazeTrigger1;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        mazeTrigger1.goOut();
    }
}
