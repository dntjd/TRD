using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public float moduleCost = 50f; // 모듈 가격
    public float upgradeCost = 100f; // 업그레이드 가격
    public GameObject specialModulePrefab; // 특수 모듈 프리팹
    public GameManager gameManager; // 게임 매니저 참조

    // 상점에서 특수 모듈 구매
    public void PurchaseModule()
    {
        if (gameManager.playerResources >= moduleCost)
        {
            gameManager.playerResources -= moduleCost;
            GameObject newModule = Instantiate(specialModulePrefab, transform.position, Quaternion.identity);
            SpecialModule module = newModule.GetComponent<SpecialModule>();

            // 예시: 특수 모듈을 타워에 장착
            if (gameManager.towers.Count > 0) // 타워가 하나 이상 있을 때만
            {
                Tower tower = gameManager.towers[0]; // 첫 번째 타워에 장착
                module.transform.SetParent(tower.transform);
                Debug.Log("모듈이 타워에 장착되었습니다!");
            }
        }
        else
        {
            Debug.Log("자원이 부족하여 모듈을 구매할 수 없습니다.");
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
