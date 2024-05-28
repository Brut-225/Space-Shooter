using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtRandom : MonoBehaviour
{
    public float RandomTimeMax = 2.0f;
    public float RandomTimeMin = 1.0f;

    public GameObject BulletPrefab;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(ShootAfterDelay());
    }

    IEnumerator ShootAfterDelay()
    {
        yield return new WaitForSeconds(Random.Range(RandomTimeMin, RandomTimeMax));
        Instantiate(BulletPrefab, transform.position, Quaternion.identity);
    }
}
