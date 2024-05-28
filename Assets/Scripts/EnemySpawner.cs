using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float RandomTimeMin = 1.0f;
    public float RandomTimeMax = 2.0f;

    public float SpawnSpeed = 1.0f;

    private float nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + Random.Range(RandomTimeMin, RandomTimeMax);
            GameObject enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            enemy.GetComponent<MoveHorizontal>().Speed = SpawnSpeed;
        }
    }
}
