using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public float moduleRateCost = 200f; // Ư�� ��� ���� Ȯ�� ����
    public float upgradeCost = 100f; // ���׷��̵� ����
    public GameObject specialModulePrefab; // Ư�� ��� ������
    public GameManager gameManager; // ���� �Ŵ��� ����


    // �������� Ư�� ��� ����
    public void PurchaseModule()
    {
        if (gameManager.playerResources >= moduleRateCost)
        {
            if (Stage.moduleRate < 15)
            {
                gameManager.playerResources -= moduleRateCost;
                Stage.moduleRate += 1;
                Debug.Log("Ư�� ��� ���� Ȯ���� ����߽��ϴ�.");
            }
            else
            {
                Debug.Log("�̹� �ִ� Ȯ���Դϴ�.");
            }
        }
        else
        {
            Debug.Log("�ڿ��� �����մϴ�.");
        }
    }

    // �������� Ÿ�� ���׷��̵� ����
    public void PurchaseTowerUpgrade(Tower tower)
    {
        if (gameManager.playerResources >= upgradeCost)
        {
            gameManager.playerResources -= upgradeCost;
            gameManager.UpgradeTower(tower); // Ÿ�� ���׷��̵� ȣ��
            Debug.Log("Ÿ�� ���׷��̵尡 �Ϸ�Ǿ����ϴ�!");
        }
        else
        {
            Debug.Log("�ڿ��� �����Ͽ� Ÿ�� ���׷��̵带 �� �� �����ϴ�.");
        }
    }
}
