using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public enum ModuleType
    {
        PowerUp,
        AttackSpeedUp
    }

    [SerializeField]
    private ModuleType moduleType;

    public void ApplyModule(Tower tower)
    {
        switch (moduleType)
        {
            case ModuleType.PowerUp:
                if (tower.CanApplyPowerUpModule())
                {
                    tower.ApplyPowerUpModule(5);
                }
                else
                {
                    Debug.LogWarning("공격력 모듈 적용 한도를 초과했습니다!");
                }
                break;

            case ModuleType.AttackSpeedUp:
                if (tower.CanApplyAttackSpeedUpModule())
                {
                    tower.ApplyAttackSpeedUpModule(-0.2f);
                }
                else
                {
                    Debug.LogWarning("공격속도 모듈 적용 한도를 초과했습니다!");
                }
                break;
        }
    }
}