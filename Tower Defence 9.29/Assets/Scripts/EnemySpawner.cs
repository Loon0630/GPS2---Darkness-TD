using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int CountEnemyAlive = 0;//Improve founction 01, when before enemy been destory or arrive end point, spwan next wave.
    public Wave[] waves;
    public Transform START;
    public float waveRate = 0.3f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, START.position, Quaternion.identity);
                CountEnemyAlive++;
                if (i != wave.count - 1)
                    yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive > 0)//If anyone enemy in the map,new enemy will not spawn.
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
    }
}
