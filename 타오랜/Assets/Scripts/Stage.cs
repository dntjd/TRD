using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Transform[] enemyPath; // ������ �̵��� ��� ����Ʈ
    public GameObject enemyPrefab; // �� ������
    public int waveCount = 5; // �� ���̺� ��
    public float spawnInterval = 2f; // �� ���� ����

    private int currentWave = 0;

    // ���̺� ����
    public void StartWave()
    {
        StartCoroutine(SpawnWave());
    }

    // ���� �����ϰ� ��θ� ���� �̵��ϵ��� ��
    private IEnumerator SpawnWave()
    {
        while (currentWave < waveCount)
        {
            // ���̺� ���� �� ���� ����
            for (int i = 0; i < currentWave + 1; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }
            currentWave++;
            yield return new WaitForSeconds(5f); // ���� ���̺� ��� �ð�
        }
    }

    // �� �ν��Ͻ� ���� �� �ʱ�ȭ
    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, enemyPath[0].position, Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.SetPath(enemyPath);
    }
}
