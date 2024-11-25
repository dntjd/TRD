using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject  enemyPrefab;    //�� ������
    [SerializeField]
    private float       spawnTime;      //�� ���� �ֱ�
    [SerializeField]
    private Transform[] wayPoints;      //���� ���������� �̵� ���
    [SerializeField]
    private PlayerHP playerHP;
    public List<Enemy> enemyList;

    private List<Enemy> EnemyList => enemyList;

    private void Awake()
    {
        enemyList = new List<Enemy>();
        //�� ���� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab);       //�� ������Ʈ ����
            Enemy enemy = clone.GetComponent<Enemy>();    //��� ������ ���� Enemy ������Ʈ

            enemy.Setup(this,wayPoints);                             //wayPoint ������ �Ű������� Setup()ȣ��
            enemyList.Add(enemy);

            yield return new WaitForSeconds(spawnTime);         //spawnTime �ð� ���� ���
        }
    }

    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy) { 

        if(type == EnemyDestroyType.Arrive)
            {
            playerHP.Takedamage(10);
        }
        enemyList.Remove(enemy);

        Destroy(enemy.gameObject);
    
    }

}
