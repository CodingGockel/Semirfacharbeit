using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdHandler2 : MonoBehaviour
{
    public PlayerMovement player;
    private int oldid;
    private int id;
    public BattleSystem2 battlesystem2;
    void Start()
    {
        id = -1;
        oldid = -1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }

    public void setid(int ID)
    {
        oldid = id;
        id = ID;
        checkid();
    }

    public void checkid()
    {
        if (oldid < 0)
        {

        }
        else if (id == oldid)
        {
            oldid = -1;
            id = -1;
        }
        else
        {
            player.takeDamage(100);
            battlesystem2.resetBattle();
            print("wrong id");
            oldid = -1;
            id = -1;
        }
    }
}
