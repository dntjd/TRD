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
                tower.IncreaseAttack(3f);
                tower.DecreaseAttackRate(0.5f);
                break;

            case ModuleType.AttackSpeedUp:
                tower.IncreaseAttackRate(2f);
                break;
        }
    }
}
