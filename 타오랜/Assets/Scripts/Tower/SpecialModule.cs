using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialModule : MonoBehaviour
{
    public enum SpecialModuleType
    {
        Penetrating, // ���� ��ž
        Slow,        // ��ȭ ��ž
        AoE          // ���� ��ž
    }

    [SerializeField]
    private SpecialModuleType moduleType;
    [SerializeField]
    private int baseAttack;
    [SerializeField]
    private float baseAttackRate;
    [SerializeField]
    private int maxUpgrades = 4;
    [SerializeField]
    private int upgradeAttackBonus;
    [SerializeField]
    private float upgradeRateBonus;

    private int upgradeCount = 0;

    public SpecialModuleType ModuleType => moduleType;
    public int CurrentAttack { get; private set; }
    public float CurrentAttackRate { get; private set; }

    private void Awake()
    {
        CurrentAttack = baseAttack;
        CurrentAttackRate = baseAttackRate;
    }

    public void UpgradeModule()
    {
        if (upgradeCount < maxUpgrades)
        {
            CurrentAttack += upgradeAttackBonus;
            CurrentAttackRate -= upgradeRateBonus;
            upgradeCount++;
        }
        else
        {
            Debug.LogWarning("Ư�� ��� ���׷��̵� �ѵ��� �ʰ��߽��ϴ�!");
        }
    }

    public void ApplyEffect(Transform target, int baseAttack)
    {
        switch (moduleType)
        {
            case SpecialModuleType.Penetrating:
                PerformPenetratingAttack(target, baseAttack);
                break;
            case SpecialModuleType.Slow:
                PerformSlowEffect(target, baseAttack);
                break;
            case SpecialModuleType.AoE:
                PerformAoEAttack(target.position, baseAttack);
                break;
        }
    }

    private void PerformPenetratingAttack(Transform target, int attack)
    {
        Debug.Log("���� ���� ����!");
    }

    private void PerformSlowEffect(Transform target, int attack)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("��ȭ ���� ����!");
            enemy.TakeDamage(attack);
            enemy.ApplySlow(0.5f);
        }
    }

    private void PerformAoEAttack(Vector3 position, int attack)
    {
        Debug.Log("���� ���� ����!");
    }
}