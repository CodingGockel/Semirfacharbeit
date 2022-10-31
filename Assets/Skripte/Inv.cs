using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public float offset;
    private float oldoffset;
    private int i;

    private void Start()
    {
        oldoffset = offset;
    }
    public void dropAllItems()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<Slot>().dropItem(offset);
            offset -= 0.15f;
        }
        offset = oldoffset;
    }
    public bool allkeys()
    {
        i = 0;
        foreach(GameObject slot in slots)
        {
            if (slot.GetComponent<Slot>().iskey())
            {
                i++;
            }
        }
        if (i==3)
        {
            return true;
        }
        return false;
    }
}
