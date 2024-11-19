using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // �̱��� ����

    public int Resource { get; private set; } = 0; // �ΰ��� �ڿ�
    public int Coin { get; private set; } = 0; // ���׷��̵忡 ���Ǵ� ����

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �ڿ� �߰�
    /// </summary>
    /// <param name="amount">�߰��� �ڿ���</param>
    public void AddResource(int amount)
    {
        Resource += amount;
        UpdateUI();
    }

    /// <summary>
    /// ���� �߰�
    /// </summary>
    /// <param name="amount">�߰��� ���η�</param>
    public void AddCoin(int amount)
    {
        Coin += amount;
        UpdateUI();
    }

    /// <summary>
    /// �ڿ� �Һ�
    /// </summary>
    /// <param name="amount">�Һ��� �ڿ���</param>
    /// <returns>�Һ� ���� ����</returns>
    public bool SpendResource(int amount)
    {
        if (Resource >= amount)
        {
            Resource -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    /// <summary>
    /// ���� �Һ�
    /// </summary>
    /// <param name="amount">�Һ��� ���η�</param>
    /// <returns>�Һ� ���� ����</returns>
    public bool SpendCoin(int amount)
    {
        if (Coin >= amount)
        {
            Coin -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    /// <summary>
    /// UI ������Ʈ
    /// </summary>
    private void UpdateUI()
    {
        // ���ҽ��� ������ UI�� ������Ʈ (���� UI �Ŵ����� ���� ����)
        Debug.Log($"Resource: {Resource}, Coin: {Coin}");
    }
}