using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private List<Tower> towers;
    [SerializeField] private Module powerUpModule;
    [SerializeField] private Module attackSpeedUpModule;
    private Tower selectedTower; // 선택된 타워

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            SelectTowerUnderMouse();
        }
    }

    void SelectTowerUnderMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePosition); // 마우스 위치에서 충돌된 타워 찾기

        if (hit != null && hit.GetComponent<Tower>() != null)
        {
            selectedTower = hit.GetComponent<Tower>();
            Debug.Log($"[선택된 타워] {selectedTower.name}");
        }
    }

    public void ApplyPowerUpModuleToSelectedTower()
    {
        if (selectedTower != null)
        {
            if (selectedTower.CanApplyPowerUpModule())
            {
                powerUpModule.ApplyModule(selectedTower);
            }
            else
            {
                Debug.LogWarning($"[타워 {selectedTower.name}] 공격력 모듈 최대치를 초과했습니다!");
            }
        }
        else
        {
            Debug.LogWarning("타워가 선택되지 않았습니다!");
        }
    }

    public void ApplyAttackSpeedUpModuleToSelectedTower()
    {
        if (selectedTower != null)
        {
            if (selectedTower.CanApplyAttackSpeedUpModule())
            {
                attackSpeedUpModule.ApplyModule(selectedTower);
            }
            else
            {
                Debug.LogWarning($"[타워 {selectedTower.name}] 공격속도 모듈 최대치를 초과했습니다!");
            }
        }
        else
        {
            Debug.LogWarning("타워가 선택되지 않았습니다!");
        }
    }
}