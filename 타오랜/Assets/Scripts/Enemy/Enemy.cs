using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int FullHp; //최대 체력
    [SerializeField] 
    protected int CurrentHp; //현재 체력
    [SerializeField]
    protected int atkDmg; //공격력(필요없다고 판단될 시 제거)
    [SerializeField]
    protected float atkSpeed; //공격속도(필요없다고 판단될 시 제거)
    [SerializeField]
    protected float MoveSpeed; // 이동속도
    [SerializeField]
    protected int reward; //처치보상
    
    private void Start()
    {
        FullHp = 30;
        CurrentHp = FullHp;
        atkDmg = 10;
        atkSpeed = 2.0f;
        MoveSpeed = 5.0f;
        reward = 10;
    }
}
