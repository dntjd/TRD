using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int FullHp;
    [SerializeField] 
    protected int CurrentHp;
    [SerializeField]
    protected int atkDmg;
    [SerializeField]
    protected float atkSpeed;
    [SerializeField]
    protected float MoveSpeed;

    
    private void Start()
    {
        FullHp = 30;
        CurrentHp = 30;
        atkDmg = 10;
        atkSpeed = 2.0f;
        MoveSpeed = 5.0f;
    }
}
