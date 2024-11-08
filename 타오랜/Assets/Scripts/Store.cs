using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public float moduleRateCost = 200f; // 특수 모듈 등장 확률 가격
    public float upgradeCost = 100f; // 업그레이드 가격
    public GameObject specialModulePrefab; // 특수 모듈 프리팹
    public GameManager gameManager; // 게임 매니저 참조


    // 상점에서 특수 모듈 구매
    public void PurchaseModule()
    {
        if (gameManager.playerResources >= moduleRateCost)
        {
            if (Stage.moduleRate < 15)
            {
                gameManager.playerResources -= moduleRateCost;
                Stage.moduleRate += 1;
                Debug.Log("특수 모듈 등장 확률이 상승했습니다.");
            }
            else
            {
                Debug.Log("이미 최대 확률입니다.");
            }
        }
        else
        {
            Debug.Log("자원이 부족합니다.");
        }
    }

    // 상점에서 타워 업그레이드 구매
    public void PurchaseTowerUpgrade(Tower tower)
    {
        if (gameManager.playerResources >= upgradeCost)
        {
            gameManager.playerResources -= upgradeCost;
            gameManager.UpgradeTower(tower); // 타워 업그레이드 호출
            Debug.Log("타워 업그레이드가 완료되었습니다!");
        }
        else
        {
            Debug.Log("자원이 부족하여 타워 업그레이드를 할 수 없습니다.");
        }
    }
}
