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
        // ��� �⺻ ���� �ʱ�ȭ
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
}