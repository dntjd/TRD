using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Transform[] enemyPath; // 적들이 이동할 경로 포인트
    public GameObject enemyPrefab; // 적 프리팹
    public int waveCount = 5; // 총 웨이브 수
    public float spawnInterval = 2f; // 적 생성 간격

    private int currentWave = 0;

    // 웨이브 시작
    public void StartWave()
    {
        StartCoroutine(SpawnWave());
    }

    // 적을 생성하고 경로를 따라 이동하도록 함
    private IEnumerator SpawnWave()
    {
        while (currentWave < waveCount)
        {
            // 웨이브 시작 시 적을 생성
            for (int i = 0; i < currentWave + 1; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }
            currentWave++;
            yield return new WaitForSeconds(5f); // 다음 웨이브 대기 시간
        }
    }

    // 적 인스턴스 생성 및 초기화
    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, enemyPath[0].position, Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.SetPath(enemyPath);
    }
}
