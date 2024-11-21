using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialModule : MonoBehaviour
{
    public enum SpecialModuleType
    {
        Penetrating, // 관통 포탑
        Slow,        // 둔화 포탑
        AoE          // 장판 포탑
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
        // 모듈 기본 상태 초기화
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
            Debug.LogWarning("특수 모듈 업그레이드 한도를 초과했습니다!");
        }
    }
}