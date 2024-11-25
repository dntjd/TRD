using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : MonoBehaviour, Upgrade
{
    [SerializeField]
    private int attackPower;
    public void Upgrade(Tower tower)
    {
        tower.AttackPowerUp(attackPower);
    }
}