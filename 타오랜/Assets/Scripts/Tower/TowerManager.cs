using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tower; // 타워 프리팹
    [SerializeField]
    private LayerMask buildableLayer; // 타일 레이어
    [SerializeField]
    private Camera mainCamera; // 메인 카메라

    [SerializeField]
    private Tilemap tilemap;

    [Header("Modules")]
    [SerializeField]
    private Module powerUpModule; // 공격력 모듈
    [SerializeField]
    private Module attackSpeedUpModule; // 공격속도 모듈
    [SerializeField]
    private SpecialModule penetratingModule; // 관통 모듈
    [SerializeField]
    private SpecialModule slowModule; // 둔화 모듈
    [SerializeField]
    private SpecialModule aoeModule; // 장판 모듈

    private GameObject selectedModuleIcon; // 현재 선택된 모듈 아이콘
    private string selectedModuleType; // 현재 선택된 모듈의 타입 (공격력, 공격속도, 관통 등)

    private void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        // 마우스 우클릭: 타워 배치
        if (Input.GetMouseButtonDown(1))
        {
            PlaceTower();
        }

        // 마우스 좌클릭: 모듈 선택 또는 적용
        if (Input.GetMouseButtonDown(0))
        {
            HandleModuleSelectionOrApplication();
        }
    }

    private void PlaceTower()
    {
        // 마우스 위치를 월드 좌표로 가져옵니다.
        Vector3 mousePosition = GetMouseWorldPosition();

        // 타일맵을 통해 월드 좌표를 타일의 그리드 좌표로 변환합니다.
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);

        // 그리드 좌표에 맞춰 타워가 정확히 중앙에 배치되도록 합니다.
        Vector3 towerPosition = tilemap.GetCellCenterWorld(gridPosition);


        // 해당 위치에 이미 타워가 존재하는지 확인
        Collider2D existingTower = Physics2D.OverlapPoint(towerPosition, buildableLayer);

        

        if (existingTower != null) // 이미 타워가 없다면
        {
            // 타워를 해당 위치에 생성합니다.
            towerPosition.x += 32f;
            towerPosition.y += 37.7f;
            towerPosition.z = 1f;

            Instantiate(tower, towerPosition, Quaternion.identity);
            Debug.Log("타워가 배치되었습니다.");
        }
        else
        {
            // 이미 타워가 존재하는 위치에서는 배치할 수 없습니다.
            Debug.LogWarning("이미 타워가 존재하는 위치입니다!");
        }
    }

    private void HandleModuleSelectionOrApplication()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject clickedObject = hit.collider.gameObject;

            // 모듈 아이콘을 클릭한 경우
            if (clickedObject.CompareTag("ModuleIcon"))
            {
                SelectModule(clickedObject);
            }
            // 타워를 클릭한 경우
            else if (clickedObject.CompareTag("Tower"))
            {
                Tower tower = clickedObject.GetComponent<Tower>();
                if (tower != null)
                {
                    ApplySelectedModuleToTower(tower);
                }
                else
                {
                    Debug.LogWarning("타워 객체를 찾을 수 없습니다!");
                }
            }
        }
    }

    private void SelectModule(GameObject moduleIcon)
    {
        // 모듈 타입을 아이콘 이름으로 구분
        string moduleType = moduleIcon.name;

        // 선택된 모듈 설정
        switch (moduleType)
        {
            case "PowerUpModuleIcon":
                selectedModuleIcon = moduleIcon;
                selectedModuleType = "PowerUp";
                Debug.Log("공격력 모듈이 선택되었습니다.");
                break;
            case "AttackSpeedUpModuleIcon":
                selectedModuleIcon = moduleIcon;
                selectedModuleType = "AttackSpeedUp";
                Debug.Log("공격속도 모듈이 선택되었습니다.");
                break;
            case "PenetratingModuleIcon":
                selectedModuleIcon = moduleIcon;
                selectedModuleType = "Penetrating";
                Debug.Log("관통 모듈이 선택되었습니다.");
                break;
            case "SlowModuleIcon":
                selectedModuleIcon = moduleIcon;
                selectedModuleType = "Slow";
                Debug.Log("둔화 모듈이 선택되었습니다.");
                break;
            case "AoEModuleIcon":
                selectedModuleIcon = moduleIcon;
                selectedModuleType = "AoE";
                Debug.Log("장판 모듈이 선택되었습니다.");
                break;
            default:
                Debug.LogWarning("알 수 없는 모듈 아이콘입니다.");
                break;
        }
    }

    private void ApplySelectedModuleToTower(Tower tower)
    {
        if (selectedModuleType == null)
        {
            Debug.LogWarning("선택된 모듈이 없습니다!");
            return;
        }

        // 선택된 모듈 타입에 따라 타워에 모듈 적용
        switch (selectedModuleType)
        {
            case "PowerUp":
                if (tower.CanApplyPowerUpModule())
                {
                    powerUpModule.ApplyModule(tower);
                    Debug.Log("공격력 모듈이 적용되었습니다.");
                }
                else
                {
                    Debug.LogWarning("공격력 모듈 최대치를 초과했습니다!");
                }
                break;
            case "AttackSpeedUp":
                if (tower.CanApplyAttackSpeedUpModule())
                {
                    attackSpeedUpModule.ApplyModule(tower);
                    Debug.Log("공격속도 모듈이 적용되었습니다.");
                }
                else
                {
                    Debug.LogWarning("공격속도 모듈 최대치를 초과했습니다!");
                }
                break;
            case "Penetrating":
                tower.ApplySpecialModule(penetratingModule);
                Debug.Log("관통 모듈이 적용되었습니다.");
                break;
            case "Slow":
                tower.ApplySpecialModule(slowModule);
                Debug.Log("둔화 모듈이 적용되었습니다.");
                break;
            case "AoE":
                tower.ApplySpecialModule(aoeModule);
                Debug.Log("장판 모듈이 적용되었습니다.");
                break;
            default:
                Debug.LogWarning("알 수 없는 모듈 타입입니다.");
                break;
        }

        // 모듈 적용 후 선택 해제
        selectedModuleIcon = null;
        selectedModuleType = null;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Z 좌표 제거 (2D 환경)
        return mousePosition;
    }
}