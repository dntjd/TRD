using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Shop_Page: MonoBehaviour
{
    void Start()=>this.gameObject.SetActive(false); // 게임을 실행했을 때 상점창이 떠있지 않도록 하기 위함
}

// 구매 시스템
public class Purchase_System : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // 타워를 구매했을 때 배치할 수 있는 타워의 개수 증가
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
                // gameManager.Coin -= price;

                Debug.Log("아이템 구매 완료!");
            }
            else
            {
                Debug.Log("재화가 부족합니다!");
            }
        }
    }
    // 업그레이드를 구매했을 때 데이터 상 존재하는 모든 타워의 능력치 향상
    public class Purchase_Upgrade : MonoBehaviour
    {
        private GameManager gameManager;
        private void Start()
        {
            gameManager = GetComponent<GameManager>();
        }

        public int price = 50;
        public void purchase_Upgrade()
        {
            if (gameManager.Coin >= price)
            {
                // gameManager.Coin -= price;

                Debug.Log("아이템 구매 완료!");
                price += 50;
            }
            else
            {
                Debug.Log("재화가 부족합니다!");
            }
        }

    }
}