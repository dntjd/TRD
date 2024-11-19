using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글턴 패턴

    public int Resource { get; private set; } = 0; // 인게임 자원
    public int Coin { get; private set; } = 0; // 업그레이드에 사용되는 코인

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
    /// 자원 추가
    /// </summary>
    /// <param name="amount">추가할 자원량</param>
    public void AddResource(int amount)
    {
        Resource += amount;
        UpdateUI();
    }

    /// <summary>
    /// 코인 추가
    /// </summary>
    /// <param name="amount">추가할 코인량</param>
    public void AddCoin(int amount)
    {
        Coin += amount;
        UpdateUI();
    }

    /// <summary>
    /// 자원 소비
    /// </summary>
    /// <param name="amount">소비할 자원량</param>
    /// <returns>소비 가능 여부</returns>
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
    /// 코인 소비
    /// </summary>
    /// <param name="amount">소비할 코인량</param>
    /// <returns>소비 가능 여부</returns>
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
    /// UI 업데이트
    /// </summary>
    private void UpdateUI()
    {
        // 리소스와 코인을 UI로 업데이트 (추후 UI 매니저와 연결 가능)
        Debug.Log($"Resource: {Resource}, Coin: {Coin}");
    }
}