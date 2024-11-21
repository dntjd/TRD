using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private List<Tower> towers;
    [SerializeField] private Module powerUpModule;
    [SerializeField] private Module attackSpeedUpModule;
    [SerializeField] private SpecialModule Penetrating;
    [SerializeField] private SpecialModule Slow;
    [SerializeField] private SpecialModule AoE;
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

    // 특수 모듈 적용
    public void ApplyPenetratingModuleToSelectedTower()
    {
        if (selectedTower != null)
        {
            selectedTower.ApplySpecialModule(Penetrating); // 관통 모듈 적용
        }
        else
        {
            Debug.LogWarning("타워가 선택되지 않았습니다!");
        }
    }

    public void ApplySlowModuleToSelectedTower()
    {
        if (selectedTower != null)
        {
            selectedTower.ApplySpecialModule(Slow); // 둔화 모듈 적용
        }
        else
        {
            Debug.LogWarning("타워가 선택되지 않았습니다!");
        }
    }

    public void ApplyAoEModuleToSelectedTower()
    {
        if (selectedTower != null)
        {
            selectedTower.ApplySpecialModule(AoE); // AoE 모듈 적용
        }
        else
        {
            Debug.LogWarning("타워가 선택되지 않았습니다!");
        }
    }
}