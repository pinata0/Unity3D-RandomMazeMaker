using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coin;
    public int minSpawnCount = 30;
    public int maxSpawnCount = 60;
    public float spawnRange = 10f;



    // Start is called before the first frame update
    void Start()
    {
        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);
        int spawnYRotation = 0;

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRange;
            spawnPosition.x = Mathf.Round(spawnPosition.x);
            spawnPosition.z = Mathf.Round(spawnPosition.z);
            spawnPosition.y = 0.3f;
            spawnYRotation = Random.Range(0, 180);
            Quaternion spawnRotation = Quaternion.Euler(0, spawnYRotation, 90);
            Instantiate(coin, spawnPosition, spawnRotation);
        }
    }

}
