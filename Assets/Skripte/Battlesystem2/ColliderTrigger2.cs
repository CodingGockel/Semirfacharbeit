using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger2 : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player != null)
        {
            OnPlayerEnterTrigger2?.Invoke(this, EventArgs.Empty);
        }
    }
}
