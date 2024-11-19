using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 스폰할 적 프리팹
    public Transform[] spawnPoints; // 적이 스폰될 위치들
    public float spawnInterval = 2f; // 적 스폰 간격
    public int enemiesPerWave = 5; // 한 웨이브당 적 수
    public int currentWave = 1; // 현재 웨이브

    private int enemiesCurrnet = 0; // 현재 웨이브에서 스폰된 적 수

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // 웨이브마다 지정된 수만큼 적 생성
            if (enemiesCurrnet < enemiesPerWave)
            {
                SpawnEnemy();
                enemiesCurrnet++;
            }
            else
            {
                // 모든 적이 스폰되었으면 다음 웨이브 대기
                yield return new WaitForSeconds(5f);
                NextWave();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length); // 랜덤 스폰 위치
        Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }

    void NextWave()
    {
        currentWave++;
        enemiesCurrnet = 0;
        enemiesPerWave += 2; // 웨이브가 진행될수록 적 수 증가
        spawnInterval = Mathf.Max(1f, spawnInterval - 0.1f); // 스폰 간격 점점 감소
    }
}

