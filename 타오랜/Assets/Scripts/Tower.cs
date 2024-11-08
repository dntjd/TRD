using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget }

public class Tower : MonoBehaviour
{
    [SerializeField]
    private GameObject projectPrefab;//�߻�ü ���
    [SerializeField]
    private Transform attackstart;//�߻�ü �߻� ��ġ
    [SerializeField]
    private int attackPower = 10; // Ÿ�� ���ݷ�
    [SerializeField]
    private float attackRate = 1.0f;// ���� �ӵ�
    [SerializeField]
    private float attackRange = 2.5f; // ���� ����

    private SpriteRenderer spriteRenderer;
    private WeaponState weaponState = WeaponState.SearchTarget;
    private Transform targetEnemy = null;
    //private PlayerGold playerGold;
    private EnemySpawner enemySpawner;

    //private Sprite TowerSprite => towerTemplete.weapon[Upgrade].sprite;
    //public float Damage => towerTemplete.weapon[Upgrade].damage;
    //public float Rate => towerTemplete.weapon[Upgrade].Rate;
    //public float Range => towerTemplete.weapon[Upgrade].Range;



    public void Setup(EnemySpawner enemySpawner)
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        this.enemySpawner = enemySpawner;
        //this.playerGold = playerGold;

        ChangeState(WeaponState.SearchTarget);

    }

    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());
        weaponState = newState;
        StartCoroutine(weaponState.ToString());
    }
    private void Update()
    {
        if (targetEnemy != null)
        {
            RotateToTarget();
        }
    }
    private void RotateToTarget()
    {
        float dx = targetEnemy.position.x - transform.position.x;
        float dy = targetEnemy.position.y - transform.position.y;

        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            float closetDistSqr = Mathf.Infinity;//�˻����� �ִ�� ����
            for (int i = 0; i < enemySpawner.enemyList.Count; i++)
            {
                float distance = Vector3.Distance(enemySpawner.enemyList[i].transform.position, transform.position);
                //�˻� ���� ���� �Ÿ��� ���ݹ��� ��, ������� �˻��� ������ �Ÿ��� ����� ���
                if (distance <= attackRange && distance <= closetDistSqr)
                {
                    closetDistSqr = distance;
                    targetEnemy = enemySpawner.enemyList[i].transform;
                }

            }

        }
    }

    private IEnumerator AttackToTarget()
    {
        while (true)
        {
            if (targetEnemy == null)//Ÿ�� ���� �˻�
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }


            float distance = Vector3.Distance(targetEnemy.position, transform.position);
            if (distance > attackRange)
            {
                targetEnemy = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            yield return new WaitForSeconds(attackRate);

            Spawnprojectile();

        }
    }

    private void Spawnprojectile()
    {

        GameObject clone = Instantiate(projectPrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<projectile>().Setup(targetEnemy, attackPower);

    }








    /*public bool Upgrade()
    {
        if (playerGold.CurrentGold < towerTemplete.weapon[Upgrade].cost)
            attackPower = upgradedAttackPower;
        attackRange = upgradedAttackRange;
        attackInterval = upgradedAttackInterval;
        Debug.Log("Ÿ���� ���׷��̵�Ǿ����ϴ�!");
    }*/



  

}

