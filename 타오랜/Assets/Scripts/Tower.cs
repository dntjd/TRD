using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private float attack = 10f;//���ݷ�
    [SerializeField]
    private float attackrate = 1f;//���ݼӵ�
    [SerializeField]
    private float range = 2.5f;//���� ����
    [SerializeField]
    private Transform target;

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
    public void IncreaseAttack(float multiplier)
    {
        attack *= multiplier;
    }

    public void IncreaseAttackRate(float multiplier)
    {
        attackrate *= multiplier;
        CancelInvoke("Attack");
        InvokeRepeating("Attack", 0f, 1f / attackrate);
    }

    public void DecreaseAttackRate(float multiplier)
    {
        attackrate *= multiplier;
        CancelInvoke("Attack");
        InvokeRepeating("Attack", 0f, 1f / attackrate);
    }


}
