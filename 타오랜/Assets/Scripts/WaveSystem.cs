using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[]       waves;
    [SerializeField]
    private EnemySpawner enemySpawner;
    private int          currentWaveIndex = -1;

    public void StartWave()
    {
        // ���� �ʿ� ���� ����, Wave�� ����������
        if  ( enemySpawner.EnemyList.Count == 0 && currentWaveIndex < waves.Length-1 )
        {
            // �ε����� ������ -1�̱� ������ ���̺� �ε��� ������ ���� ���� ��
            currentWaveIndex ++;
            // EnemySpawner�� StartWave() �Լ� ȣ��. ���� ���̺� ���� ����
            enemySpawner.StartWave(waves[currentWaveIndex]);
        }
    }
}

[System.Serializable]
public struct Wave
{
    public float        spawnTime;      // ���� ���̺� �� ���� �ֱ�
    public int          macEnemyCount;  // ���� ���̺� �� ���� ����
    public GameObject[] enemyPrefabs;   // ���� ���̺� �� ���� ����
}