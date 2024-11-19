using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int FullHp; //�ִ� ü��
    [SerializeField] 
    protected int CurrentHp; //���� ü��
    [SerializeField]
    protected int atkDmg; //���ݷ�(�ʿ���ٰ� �Ǵܵ� �� ����)
    [SerializeField]
    protected float atkSpeed; //���ݼӵ�(�ʿ���ٰ� �Ǵܵ� �� ����)
    [SerializeField]
    protected float MoveSpeed; // �̵��ӵ�
    [SerializeField]
    protected int reward; //óġ����
    
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
