using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public float moduleRateCost = 200f; // 특수 모듈 등장 확률 가격
    public float upgradeCost = 100f; // 업그레이드 가격
    public GameObject specialModulePrefab; // 특수 모듈 프리팹
    public GameManager gameManager; // 게임 매니저 참조
    public float towerPlacementCost = 50f; // 타워 배치 비용


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

    // 타워 배치 (플레이어가 타워를 배치하려고 할 때 호출)
    public void PlaceTower(Vector2 position)
    {
        if (currentState == GameState.Playing && playerResources >= towerPlacementCost)
        {
            GameObject newTower = Instantiate(towerPrefab, position, Quaternion.identity, towerParent);
            Tower towerScript = newTower.GetComponent<Tower>();
            towers.Add(towerScript);
            playerResources -= towerPlacementCost; // 자원 차감
            Debug.Log("타워 배치 완료! 남은 자원: " + playerResources);
        }
        else if (playerResources < towerPlacementCost)
        {
            Debug.Log("자원이 부족합니다!");
        }
    }
}
