using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int FullHp; //최대 체력
    [SerializeField] 
    protected int CurrentHp; //현재 체력
    [SerializeField]
    protected int atkDmg; //공격력(필요없다고 판단될 시 제거)
    [SerializeField]
    protected float atkSpeed; //공격속도(필요없다고 판단될 시 제거)
    [SerializeField]
    protected float MoveSpeed; // 이동속도
    [SerializeField]
    protected int reward; //처치보상

    private Transform target; // 이동할 목표
    private int waypointIndex = 0; // 현재 웨이포인트 인덱스

    private void Start()
    {
        InitializeStats();
        target = WaypointManager.Instance.GetWaypoint(waypointIndex); // 첫 번째 웨이포인트 설정
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    /// <summary>
    /// 적의 초기 스탯 설정
    /// </summary>
    private void InitializeStats()
    {
        FullHp = 30;
        CurrentHp = FullHp;
        atkDmg = 10;
        atkSpeed = 2.0f;
        MoveSpeed = 5.0f;
        reward = 10;
    }

    /// <summary>
    /// 목표 지점을 향해 이동
    /// </summary>
    private void MoveTowardsTarget()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * MoveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            waypointIndex++;
            target = WaypointManager.Instance.GetWaypoint(waypointIndex);
        }
    }

    /// <summary>
    /// 적이 데미지를 받을 때 호출
    /// </summary>
    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// 적 사망 처리
    /// </summary>
    private void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.AddReward(reward); // 플레이어에게 보상 추가
    }
}
}
