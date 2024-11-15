using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private int attack = 10;//���ݷ�
    [SerializeField]
    private float attackrate = 1f;//���ݼӵ�
    [SerializeField]
    private float range = 2.5f;//���� ����
    [SerializeField]
    private Transform target;

    private int powerUpModuleCount = 0; // ����� ���ݷ� ��� ����
    private int attackSpeedUpModuleCount = 0; // ����� ���ݼӵ� ��� ����
    private const int maxPowerUpModules = 4; // ���ݷ� ��� �ִ� ����
    private const int maxAttackSpeedUpModules = 4; // ���ݼӵ� ��� �ִ� ����

    // Start is called before the first frame update
    private void Start()//���� ���� �� �� ����, ���� �غ�
    {
        InvokeRepeating("FindTarget", 0f, 0.5f);
        InvokeRepeating("Attack", 0f, 1f / attackrate);
    }
    private void Attack()//Ÿ���� ����
    {
        if (target != null)
        {
            Enemy enemy = target.GetComponent<enemy>;
            if (enemy != null)
            {
                enemy.Takedamage(attack);
            }
        }


    }
    private void FindTarget()
    {
        // ���� ���� ��� �� Ž��
        Collider2D[] RangeEnemy = Physics2D.OverlapCircleAll(transform.position, range);

        // ���� ����� �� ã��
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D collider in RangeEnemy)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, collider.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = collider.transform;
                }
            }
        }

        // Ÿ�� ����
        target = closestEnemy;

    }


    public bool CanApplyPowerUpModule()
    {
        return powerUpModuleCount < maxPowerUpModules;
    }

    public bool CanApplyAttackSpeedUpModule()
    {
        return attackSpeedUpModuleCount < maxAttackSpeedUpModules;
    }

    public void ApplyPowerUpModule()
    {
        if (CanApplyPowerUpModule())
        {
            attack += 5;
            powerUpModuleCount++;
        }
        else
        {
            Debug.LogWarning("���ݷ� ��� ���� �ѵ��� �ʰ��߽��ϴ�!");
        }
    }

    public void ApplyAttackSpeedUpModule()
    {
        if (CanApplyAttackSpeedUpModule())
        {
            attackrate *= 1.2f;
            CancelInvoke("Attack");
            InvokeRepeating("Attack", 0f, 1f / attackrate);
            attackSpeedUpModuleCount++;
        }
        else
        {
            Debug.LogWarning("���ݼӵ� ��� ���� �ѵ��� �ʰ��߽��ϴ�!");
        }
    }
}



