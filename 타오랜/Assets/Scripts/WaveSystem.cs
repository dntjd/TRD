using UnityEngine;

public class WaveSystem : MonoBehaviour
{
}

[System.Serializable]
public struct Wave
{
    public float        spawnTime;      // ���� ���̺� �� ���� �ֱ�
    public int          macEnemyCount;  // ���� ���̺� �� ���� ����
    public GameObject[] enemyPrefabs;   // ���� ���̺� �� ���� ����
}