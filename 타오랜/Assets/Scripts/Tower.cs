using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget }

public class Tower : MonoBehaviour
{
    [SerializeField]
    private GameObject projectPrefab;//발사체 모양
    [SerializeField]
    private Transform attackstart;//발사체 발사 위치
    [SerializeField]
    private int attackPower = 10; // 타워 공격력
    [SerializeField]
    private float attackRate = 1.0f;// 공격 속도
    [SerializeField]
    private float attackRange = 2.5f; // 공격 범위

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
            float closetDistSqr = Mathf.Infinity;//검색범위 최대로 설정
            for (int i = 0; i < enemySpawner.enemyList.Count; i++)
            {
                float distance = Vector3.Distance(enemySpawner.enemyList[i].transform.position, transform.position);
                //검사 중인 적의 거리가 공격범위 안, 현재까지 검사한 적보다 거리가 가까운 경우
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
            if (targetEnemy == null)//타겟 존재 검사
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
        Debug.Log("타워가 업그레이드되었습니다!");
    }*/



  

}

