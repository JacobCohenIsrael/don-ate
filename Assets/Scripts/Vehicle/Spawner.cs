using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float gapX;
    [SerializeField] float spawnInterval;
    [SerializeField] float spawnProbability;

    [SerializeField] GameObject Nagmash;
    private Vector3[] spawnPointsOffsets = new Vector3[3];
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            spawnPointsOffsets[i] = new Vector3(i * gapX, 0, 0);
        }

        StartCoroutine(SpawnForever());
    }

    void SpawnNagmash(int index)
    {
        Transform spawnPoint = this.transform;
        Instantiate(Nagmash, spawnPoint.position + spawnPointsOffsets[index], Quaternion.identity);
    }

    private System.Collections.IEnumerator SpawnForever()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                float randomValue = Random.Range(0f, 1f);

                if (randomValue < spawnProbability)
                {
                    SpawnNagmash(i);
                }
            }

            yield return new WaitForSeconds(spawnInterval);

        }
    }

}
