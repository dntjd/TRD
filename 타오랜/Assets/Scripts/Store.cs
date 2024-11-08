using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public float moduleCost = 50f; // ��� ����
    public float upgradeCost = 100f; // ���׷��̵� ����
    public GameObject specialModulePrefab; // Ư�� ��� ������
    public GameManager gameManager; // ���� �Ŵ��� ����

    // �������� Ư�� ��� ����
    public void PurchaseModule()
    {
        if (gameManager.playerResources >= moduleCost)
        {
            gameManager.playerResources -= moduleCost;
            GameObject newModule = Instantiate(specialModulePrefab, transform.position, Quaternion.identity);
            SpecialModule module = newModule.GetComponent<SpecialModule>();

            // ����: Ư�� ����� Ÿ���� ����
            if (gameManager.towers.Count > 0) // Ÿ���� �ϳ� �̻� ���� ����
            {
                Tower tower = gameManager.towers[0]; // ù ��° Ÿ���� ����
                module.transform.SetParent(tower.transform);
                Debug.Log("����� Ÿ���� �����Ǿ����ϴ�!");
            }
        }
        else
        {
            Debug.Log("�ڿ��� �����Ͽ� ����� ������ �� �����ϴ�.");
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
