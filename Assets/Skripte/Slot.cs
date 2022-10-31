using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inv inventory;
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inv>();
    }

    private void Update()
    {
        if (transform.childCount<=0)
        {
            inventory.isFull[i] = false;
        }
    }

    public void dropItem(float offset)
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().spawnDroppedItem(offset);
            GameObject.Destroy(child.gameObject);

        }
    }

    public bool iskey()
    {
        if (transform.childCount>0)
        {
            if (this.transform.GetChild(0).CompareTag("key"))
            {
                return true;
            }
        }
        return false;
    }
}
