using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    void Start()=>this.gameObject.SetActive(false); // ������ �������� �� ����â�� ������ �ʵ��� �ϱ� ����
}

// ���� �ý���
public class Purchase_System : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    public void Purchase(int price)
    {
        if (gameManager.Coin >= price)
        {
            gameManager.coin -= price;
            Debug.Log("������ ���� �Ϸ�!");
        }
        else
        {
            Debug.Log("��ȭ�� �����մϴ�!");
        }
    }
}



// Ÿ���� �������� �� Ÿ�� ������Ʈ�� �����Ͽ� ������ ��ġ�� ����
public class Purchase_Tower : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    public int Purchase_System(int tower);
    void Tower_Purachase()
    {
        GameObject tower = (GameObject)Instantiate(Tower, new Vector2(), Quaternion.identity);   // Vector2�� ()�ȿ� ���� �� ��ǥ, identity�ڸ��� ��ü�� ����
    }
}

// ���׷��̵带 �������� �� ������ �� �����ϴ� ��� Ÿ���� �ɷ�ġ ���
public class Purchase_Upgrade : MonoBehaviour
{
    public int coin;
    public int price;
    public void purchase_upgrade()
    {

    }
    
}