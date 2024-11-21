using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpecialModule;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private int baseAttack = 10; // �⺻ ���ݷ�
    [SerializeField]
    private float baseAttackRate = 1f; // �⺻ ���ݼӵ�
    [SerializeField]
    private float range = 2.5f; // ���� ����
    [SerializeField]
    private Transform target;
    [SerializeField]
    private GameObject projectilePrefab;

    private int powerUpModuleCount = 0; // ���ݷ� ��� ����
    private int attackSpeedUpModuleCount = 0; // ���ݼӵ� ��� ����
    private const int maxPowerUpModules = 4; // ���ݷ� ��� �ִ� ����
    private const int maxAttackSpeedUpModules = 4; // ���ݼӵ� ��� �ִ� ����

    private SpecialModule currentSpecialModule; // ���� ����� Ư�� ���
    private int specialModuleCount = 0; // ���� Ư�� ��� ���� Ƚ��
    private const int maxSpecialModules = 4; // ���� Ư�� ��� �ִ� ����

    private void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.5f);
        InvokeRepeating("Attack", 0f, 1f / baseAttackRate);
    }

    private void Attack()
    {
        if (target != null)
        {
            // ����ü ����
            GameObject projectileObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            if (currentSpecialModule != null)
            {
                switch (currentSpecialModule.ModuleType)
                {
                    case SpecialModuleType.Penetrating:
                        // ���� ����ü ����
                        projectile.Initialize(target, baseAttack, true);
                        break;

                    case SpecialModuleType.AoE:
                        // AoE ����ü ����
                        projectile.Initialize(target, baseAttack, false, true, false, 2.5f, 5f, 1f); // AoE �Ӽ� ����
                        break;

                    case SpecialModuleType.Slow:
                        // ��ȭ ��ž ����ü ����
                        projectile.Initialize(target, baseAttack, false, false, true); // ��ȭ ��ž ����
                        break;

                    default:
                        // �⺻ ����ü ����
                        projectile.Initialize(target, baseAttack);
                        break;
                }
            }
            else
            {
                // �Ϲ� ����ü
                projectile.Initialize(target, baseAttack);
            }
        }
    }

    private void FindTarget()
    {
        Collider2D[] rangeEnemies = Physics2D.OverlapCircleAll(transform.position, range);

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D collider in rangeEnemies)
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

        target = closestEnemy;
    }
    public void ApplySpecialModule(SpecialModule specialModule)
    {
        if (currentSpecialModule != null)
        {
            // �̹� Ư�� ����� Ȱ��ȭ�� ���
            if (currentSpecialModule.ModuleType == specialModule.ModuleType)
            {
                // ������ Ư�� ��⸸ ���� ����
                if (specialModuleCount <= maxSpecialModules)
                {
                    currentSpecialModule.UpgradeModule();
                    specialModuleCount++;
                }
                else
                {
                    Debug.LogWarning("������ Ư�� ����� �ִ� ���� �ѵ��� �ʰ��߽��ϴ�!");
                }
            }
            else
            {
                Debug.LogWarning("�ٸ� ������ Ư�� ����� ������ �� �����ϴ�!");
            }
        }
        else
        {
            // ���� �Ϲ� ����� ��� ����
            ResetModules();

            // Ư�� ��� ó�� ����
            currentSpecialModule = specialModule;
            specialModuleCount = 1;

            // �� Ư�� ��ž�� �´� �⺻ ���� ����
            switch (specialModule.ModuleType)
            {
                case SpecialModuleType.Penetrating:
                    baseAttack = 50;
                    baseAttackRate = 10f; // 10/s
                    break;

                case SpecialModuleType.Slow:
                    baseAttack = 10;
                    baseAttackRate = 1f; // 1/s
                    break;

                case SpecialModuleType.AoE:
                    baseAttack = 10;
                    baseAttackRate = 1f / 15f; // 1/15s
                    break;
            }

            // Ư�� ����� ���� ���� Ȱ��ȭ
            CancelInvoke("Attack");
            InvokeRepeating("Attack", 0f, 1f / baseAttackRate);
        }
    }

    // ���ݷ� ��� ����
    public void ApplyPowerUpModule(int attackBoost)
    {
        if (currentSpecialModule != null)
        {
            Debug.LogWarning("Ư�� ����� Ȱ��ȭ�� ��� �Ϲ� ����� ������ �� �����ϴ�!");
            return;
        }

        if (powerUpModuleCount <= maxPowerUpModules)
        {
            baseAttack += attackBoost;
            powerUpModuleCount++;
            Debug.Log("���ݷ� ��� ����: " + attackBoost);
        }
        else
        {
            Debug.LogWarning("���ݷ� ����� �ִ� ���� �ѵ��� �ʰ��߽��ϴ�!");
        }
    }

    // ���ݼӵ� ��� ����
    public void ApplyAttackSpeedUpModule(float attackRateBoost)
    {
        if (currentSpecialModule != null)
        {
            Debug.LogWarning("Ư�� ����� Ȱ��ȭ�� ��� �Ϲ� ����� ������ �� �����ϴ�!");
            return;
        }

        if (attackSpeedUpModuleCount <= maxAttackSpeedUpModules)
        {
            baseAttackRate += attackRateBoost;
            attackSpeedUpModuleCount++;
            Debug.Log("���ݼӵ� ��� ����: " + attackRateBoost);
        }
        else
        {
            Debug.LogWarning("���ݼӵ� ����� �ִ� ���� �ѵ��� �ʰ��߽��ϴ�!");
        }

        // ���ݼӵ� ���� �ݿ�
        CancelInvoke("Attack");
        InvokeRepeating("Attack", 0f, 1f / baseAttackRate);
    }

    // ��� ���� ���� ���� Ȯ��
    public bool CanApplyPowerUpModule()
    {
        return currentSpecialModule == null && powerUpModuleCount < maxPowerUpModules;
    }

    public bool CanApplyAttackSpeedUpModule()
    {
        return currentSpecialModule == null && attackSpeedUpModuleCount < maxAttackSpeedUpModules;
    }

    public void ResetModules()
    {
        baseAttack = 10;
        baseAttackRate = 1f;
        powerUpModuleCount = 0;
        attackSpeedUpModuleCount = 0;
        currentSpecialModule = null;
        specialModuleCount = 0;
        Debug.Log("��� ����� �ʱ�ȭ�Ǿ����ϴ�.");
    }
}