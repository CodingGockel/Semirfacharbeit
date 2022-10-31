using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem2 : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active,
        BattleOver,
    }
    public ColliderTrigger2 colliderTrigger2;
    [SerializeField] private Wave[] wavearray;
    private State state;
    public GameObject wall;
    public GameObject chest;
    public GameObject Player;
    public Transform respawnpoint;
    private void Awake()
    {
        state = State.Idle;
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        colliderTrigger2.OnPlayerEnterTrigger2 += ColliderTrigger_OnPlayerEnterTrigger;
        wall.SetActive(false);
        chest.SetActive(false);
    }
    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if (state == State.Idle)
        {
            StartBattle();
            state = State.Active;
        }

    }
    private void StartBattle()
    {
        print("StartBattle");
        state = State.Active;
        wall.SetActive(true);
        Player.GetComponent<PlayerMovement>().respawnPoint = respawnpoint;
    }


    private void Update()
    {
        switch (state)
        {
            case State.Active:

                foreach (Wave wave in wavearray)
                {
                    if (wave.IsWaveOver())
                    {
                        //Player.GetComponent<PlayerMovement>().healfull();
                        continue;
                    }
                    else
                    {
                        wave.Update();
                        break;
                    }
                }
                TestBattleOver();
                break;
        }
    }
    private void TestBattleOver()
    {
        if (state == State.Active)
        {
            if (AreWavesOver())
            {
                state = State.BattleOver;
                print("Battle Over");
                wall.SetActive(false);
                chest.SetActive(true);
            }
        }
    }

    private bool AreWavesOver()
    {
        foreach (Wave wave in wavearray)
        {
            if (wave.IsWaveOver())
            {

            }
            else
            {
                return false;
            }

        }
        return true;
    }

    public void resetWaves()
    {
        foreach (Wave wave in wavearray)
        {
            wave.refillWave();
        }
    }

    public void resetBattle()
    {
        resetWaves();
        state = State.Idle;
        wall.SetActive(false);
        print("Battle reset");
    }

    [System.Serializable]
    private class Wave
    {
        [SerializeField] private GameObject[] enemySpawnArray;
        //[SerializeField] private float timer;
        private bool hasSpawed = false;
        public void Update()
        {
            if (hasSpawed == false)
            {
                SpawnEnemies();
            }

        }
        private void SpawnEnemies()
        {
            foreach (GameObject enemySpawn in enemySpawnArray)
            {

                if (enemySpawn.GetComponent<Enemy>() != null)
                {
                    enemySpawn.GetComponent<Enemy>().Spawn();
                }
                else
                {
                    enemySpawn.GetComponent<Enemy2>().Spawn();
                }
            }
            if (hasSpawed == false)
            {
                hasSpawed = true;
            }
        }
        public bool IsWaveOver()
        {
            foreach (GameObject enemySpawn in enemySpawnArray)
            {
                if (enemySpawn.activeSelf == true)
                {
                    return false;
                }
                else if (hasSpawed == false)
                {
                    return false;
                }
            }
            return true;
        }
        public void refillWave()
        {
            hasSpawed = false;
            foreach (GameObject enemySpawn in enemySpawnArray)
            {
                if (enemySpawn.activeSelf == true)
                {
                    enemySpawn.SetActive(false);
                }
            }
        }
    }
}
