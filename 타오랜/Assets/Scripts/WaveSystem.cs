using UnityEngine;

public class WaveSystem : MonoBehaviour
{
}

[System.Serializable]
public struct Wave
{
    public float        spawnTime;      // 현재 웨이브 적 생성 주기
    public int          macEnemyCount;  // 현재 웨이브 적 등장 숫자
    public GameObject[] enemyPrefabs;   // 현재 웨이브 적 등장 종류
}