using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    void Start()=>this.gameObject.SetActive(false); // ������ �������� �� ����â�� ������ �ʵ��� �ϱ� ����
    {
        
    }
    void Update()
    {
        
    }
}

// Ÿ���� �������� �� Ÿ�� ������Ʈ�� �����Ͽ� ������ ��ġ�� ����
public class Purchase_Tower : MonoBehaviour
{
    public GameObject Tower;
    void Tower_Purachase()
    {
        GameObject tower = (GameObject)Instantiate(Tower, new Vector2(), Quaternion.identity);   // Vector2�� ()�ȿ� ���� �� ��ǥ, identity�ڸ��� ��ü�� ����
    }
}

// ���׷��̵带 �������� �� ������ �� �����ϴ� ��� Ÿ���� �ɷ�ġ ���
public class Purchase_Upgrade : MonoBehaviour
{
    public Purchase_Upgrade tower;
    
}