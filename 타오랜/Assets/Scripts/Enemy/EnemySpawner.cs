using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �� ������
    public Transform[] spawnPoints; // ���� ������ ��ġ��
    public float spawnInterval = 2f; // �� ���� ����
    public int enemiesPerWave = 5; // �� ���̺�� �� ��
    public int currentWave = 1; // ���� ���̺�

    private int enemiesCurrnet = 0; // ���� ���̺꿡�� ������ �� ��

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // ���̺긶�� ������ ����ŭ �� ����
            if (enemiesCurrnet < enemiesPerWave)
            {
                SpawnEnemy();
                enemiesCurrnet++;
            }
            else
            {
                // ��� ���� �����Ǿ����� ���� ���̺� ���
                yield return new WaitForSeconds(5f);
                NextWave();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length); // ���� ���� ��ġ
        Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }

    void NextWave()
    {
        currentWave++;
        enemiesCurrnet = 0;
        enemiesPerWave += 2; // ���̺갡 ����ɼ��� �� �� ����
        spawnInterval = Mathf.Max(1f, spawnInterval - 0.1f); // ���� ���� ���� ����
    }
}

