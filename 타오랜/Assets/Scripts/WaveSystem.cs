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
        // 현재 맵에 적이 없고, Wave가 남아있으면
        if  ( enemySpawner.EnemyList.Count == 0 && currentWaveIndex < waves.Length-1 )
        {
            // 인덱스의 시작이 -1이기 때문에 웨이브 인덱스 증가를 제일 먼저 함
            currentWaveIndex ++;
            // EnemySpawner의 StartWave() 함수 호출. 현재 웨이브 정보 제공
            enemySpawner.StartWave(waves[currentWaveIndex]);
        }
    }
}

[System.Serializable]
public struct Wave
{
    public float        spawnTime;      // 현재 웨이브 적 생성 주기
    public int          macEnemyCount;  // 현재 웨이브 적 등장 숫자
    public GameObject[] enemyPrefabs;   // 현재 웨이브 적 등장 종류
}