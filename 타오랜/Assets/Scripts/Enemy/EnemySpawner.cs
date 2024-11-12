using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject Enemy;
    public GameObject Spawner;

    void SpawnEnemy()
    {
        if (enableSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(Enemy, Spawner.transform.position, Quaternion.identity);
        }
    }
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 1);
    }
    private void Update()
    {
        
    }
}
