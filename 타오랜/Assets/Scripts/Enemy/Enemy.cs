using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int FullHp; //�ִ� ü��
    [SerializeField] 
    protected int CurrentHp; //���� ü��
    [SerializeField]
    protected int atkDmg; //���ݷ�(�ʿ���ٰ� �Ǵܵ� �� ����)
    [SerializeField]
    protected float atkSpeed; //���ݼӵ�(�ʿ���ٰ� �Ǵܵ� �� ����)
    [SerializeField]
    protected float MoveSpeed; // �̵��ӵ�
    [SerializeField]
    protected int reward; //óġ����

    private Transform target; // �̵��� ��ǥ
    private int waypointIndex = 0; // ���� ��������Ʈ �ε���

    private void Start()
    {
        InitializeStats();
        target = WaypointManager.Instance.GetWaypoint(waypointIndex); // ù ��° ��������Ʈ ����
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    /// <summary>
    /// ���� �ʱ� ���� ����
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
    /// ��ǥ ������ ���� �̵�
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
    /// ���� �������� ���� �� ȣ��
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
    /// �� ��� ó��
    /// </summary>
    private void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.AddReward(reward); // �÷��̾�� ���� �߰�
    }
}
}
