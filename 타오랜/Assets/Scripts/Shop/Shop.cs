using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Shop_Page: MonoBehaviour
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

    // Ÿ���� �������� �� ��ġ�� �� �ִ� Ÿ���� ���� ����
    public class Purchase_Tower : MonoBehaviour
    {
        private GameManager gameManager;
        private void Start()
        {
            gameManager = GetComponent<GameManager>();
        }
        public void Tower_Purchase(int price)
        {
            price = 100;
            if (gameManager.Coin  >= price)
            {
                //gameManager.Coin -= price;

                Debug.Log("������ ���� �Ϸ�!");
            }
            else
            {
                Debug.Log("��ȭ�� �����մϴ�!");
            }
        }
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