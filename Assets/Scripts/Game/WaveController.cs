using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class WaveControl : MonoBehaviour
{
    [SerializeField]
    private SpawnerControl spawner0;

    [SerializeField]
    private SpawnerControl spawner1;

    [SerializeField]
    private SpawnerControl spawner2;

    [SerializeField]
    private GameObject finalBoss;

    [SerializeField]
    private int enemiesWaveOne;

    [SerializeField]
    private int enemiesWaveTwo;

    [SerializeField]
    private int enemiesWaveThree;

    [SerializeField]
    private WeaponHit player;

    // [SerializeField]
    // private float interval = 3.5f;

    private bool waveTwoSpawned = false;
    private bool waveThreeSpawned = false;
    private bool finalBossSpawned = false;

    private IEnumerator waveCoroutine(int amount)
    {
        yield return true;

        // Debug.Log("Summoning this amount of zombies: " + amount);

        // for (int i = 0; i < amount; ++i)
        // {
        //     int spawner = Random.RandomRange(0, 3);

        //     switch (spawner)
        //     {
        //         case 0:
        //             spawner0.spawnEnemy();
        //             break;
        //         case 1:
        //             spawner1.spawnEnemy();
        //             break;
        //         case 2:
        //             spawner2.spawnEnemy();
        //             break;
        //         default:
        //             break;
        //     }
        // }

        int remaining = amount;

        int subAmount = Random.Range(1, (int)Mathf.Floor(remaining * 0.6f));

        spawner0.spawnWave(subAmount);

        remaining -= subAmount;

        subAmount = Random.Range(1, (int)Mathf.Floor(remaining * 0.6f));

        spawner1.spawnWave(subAmount);

        remaining -= subAmount;

        subAmount = Random.Range(1, (int)Mathf.Floor(remaining * 0.6f));

        spawner2.spawnWave(subAmount);
    }

    private void summonFinalBoss()
    {
        Debug.Log("Summoning final boss");
        finalBoss.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(waveCoroutine(enemiesWaveOne));
    }

    void Update()
    {
        if (player.enemiesKilled == enemiesWaveOne && !waveTwoSpawned)
        {
            Debug.Log("Wave 2 of " + enemiesWaveTwo);
            waveTwoSpawned = true;
            StartCoroutine(waveCoroutine(enemiesWaveTwo));
        }
        else if (player.enemiesKilled == enemiesWaveOne + enemiesWaveTwo && !waveThreeSpawned)
        {
            Debug.Log("Wave 3 of " + enemiesWaveThree);
            waveThreeSpawned = true;
            StartCoroutine(waveCoroutine(enemiesWaveThree));
        }
        else if (
            player.enemiesKilled == enemiesWaveOne + enemiesWaveTwo + enemiesWaveThree
            && !finalBossSpawned
        )
        {
            Debug.Log("Final boss");
            finalBossSpawned = true;
            summonFinalBoss();
        }
    }
}
