using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tower; // Ÿ�� ������
    [SerializeField]
    private LayerMask buildableLayer; // Ÿ�� ���̾�
    [SerializeField]
    private Camera mainCamera; // ���� ī�޶�

    [Header("Modules")]
    [SerializeField]
    private Module powerUpModule; // ���ݷ� ���
    [SerializeField]
    private Module attackSpeedUpModule; // ���ݼӵ� ���
    [SerializeField]
    private SpecialModule penetratingModule; // ���� ���
    [SerializeField]
    private SpecialModule slowModule; // ��ȭ ���
    [SerializeField]
    private SpecialModule aoeModule; // ���� ���

    private GameObject selectedModuleIcon; // ���� ���õ� ��� ������
    private string selectedModuleType; // ���� ���õ� ����� Ÿ�� (���ݷ�, ���ݼӵ�, ���� ��)

    private void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        // ���콺 ��Ŭ��: Ÿ�� ��ġ
        if (Input.GetMouseButtonDown(1))
        {
            PlaceTower();
        }

        // ���콺 ��Ŭ��: ��� ���� �Ǵ� ����
        if (Input.GetMouseButtonDown(0))
        {
            HandleModuleSelectionOrApplication();
        }
    }

    private void PlaceTower()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Collider2D tileCollider = Physics2D.OverlapPoint(mousePosition, buildableLayer);

        if (tileCollider != null)
        {
            // Ÿ�� ��ġ�� �������� Ÿ�� ��ġ
            Vector3 towerPosition = tileCollider.transform.position;

            // Ÿ���� Z ��ǥ�� 1�� �����Ͽ� Ÿ�ϸ� �տ� ��ġ
            towerPosition.z = 1f;

            Instantiate(tower, towerPosition, Quaternion.identity);
            Debug.Log("Ÿ���� ��ġ�Ǿ����ϴ�.");
        }
        else
        {
            Debug.LogWarning("��ġ ���� ������ �ƴմϴ�!");
        }
    }

    private void HandleModuleSelectionOrApplication()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject clickedObject = hit.collider.gameObject;

            // ��� �������� Ŭ���� ���
            if (clickedObject.CompareTag("ModuleIcon"))
            {
                SelectModule(clickedObject);
            }
            // Ÿ���� Ŭ���� ���
            else if (clickedObject.CompareTag("Tower"))
            {
                Tower tower = clickedObject.GetComponent<Tower>();
                if (tower != null)
                {
                    ApplySelectedModuleToTower(tower);
                }
                else
                {
                    Debug.LogWarning("Ÿ�� ��ü�� ã�� �� �����ϴ�!");
                }
            }
        }
    }

    private void SelectModule(GameObject moduleIcon)
    {
        // ��� Ÿ���� ������ �̸����� ����
        string moduleType = moduleIcon.name;

        // ���õ� ��� ����
        switch (moduleType)
        {
            case "PowerUpModuleIcon":
                selectedModuleIcon = moduleIcon;
                selectedModuleType = "PowerUp";
                Debug.Log("���ݷ� ����� ���õǾ����ϴ�.");
                break;
            case "AttackSpeedUpModuleIcon":
                selectedModuleIcon = moduleIcon;
                selectedModuleType = "AttackSpeedUp";
                Debug.Log("���ݼӵ� ����� ���õǾ����ϴ�.");
                break;
            case "PenetratingModuleIcon":
                selectedModuleIcon = moduleIcon;
                selectedModuleType = "Penetrating";
                Debug.Log("���� ����� ���õǾ����ϴ�.");
                break;
            case "SlowModuleIcon":
                selectedModuleIcon = moduleIcon;
                selectedModuleType = "Slow";
                Debug.Log("��ȭ ����� ���õǾ����ϴ�.");
                break;
            case "AoEModuleIcon":
                selectedModuleIcon = moduleIcon;
                selectedModuleType = "AoE";
                Debug.Log("���� ����� ���õǾ����ϴ�.");
                break;
            default:
                Debug.LogWarning("�� �� ���� ��� �������Դϴ�.");
                break;
        }
    }

    private void ApplySelectedModuleToTower(Tower tower)
    {
        if (selectedModuleType == null)
        {
            Debug.LogWarning("���õ� ����� �����ϴ�!");
            return;
        }

        // ���õ� ��� Ÿ�Կ� ���� Ÿ���� ��� ����
        switch (selectedModuleType)
        {
            case "PowerUp":
                if (tower.CanApplyPowerUpModule())
                {
                    powerUpModule.ApplyModule(tower);
                    Debug.Log("���ݷ� ����� ����Ǿ����ϴ�.");
                }
                else
                {
                    Debug.LogWarning("���ݷ� ��� �ִ�ġ�� �ʰ��߽��ϴ�!");
                }
                break;
            case "AttackSpeedUp":
                if (tower.CanApplyAttackSpeedUpModule())
                {
                    attackSpeedUpModule.ApplyModule(tower);
                    Debug.Log("���ݼӵ� ����� ����Ǿ����ϴ�.");
                }
                else
                {
                    Debug.LogWarning("���ݼӵ� ��� �ִ�ġ�� �ʰ��߽��ϴ�!");
                }
                break;
            case "Penetrating":
                tower.ApplySpecialModule(penetratingModule);
                Debug.Log("���� ����� ����Ǿ����ϴ�.");
                break;
            case "Slow":
                tower.ApplySpecialModule(slowModule);
                Debug.Log("��ȭ ����� ����Ǿ����ϴ�.");
                break;
            case "AoE":
                tower.ApplySpecialModule(aoeModule);
                Debug.Log("���� ����� ����Ǿ����ϴ�.");
                break;
            default:
                Debug.LogWarning("�� �� ���� ��� Ÿ���Դϴ�.");
                break;
        }

        // ��� ���� �� ���� ����
        selectedModuleIcon = null;
        selectedModuleType = null;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Z ��ǥ ���� (2D ȯ��)
        return mousePosition;
    }
}