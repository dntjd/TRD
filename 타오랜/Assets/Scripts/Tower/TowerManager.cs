using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private List<Tower> towers;
    [SerializeField] private Module powerUpModule;
    [SerializeField] private Module attackSpeedUpModule;
    private Tower selectedTower; // ���õ� Ÿ��

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            SelectTowerUnderMouse();
        }
    }

    void SelectTowerUnderMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePosition); // ���콺 ��ġ���� �浹�� Ÿ�� ã��

        if (hit != null && hit.GetComponent<Tower>() != null)
        {
            selectedTower = hit.GetComponent<Tower>();
            Debug.Log($"[���õ� Ÿ��] {selectedTower.name}");
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
                Debug.LogWarning($"[Ÿ�� {selectedTower.name}] ���ݷ� ��� �ִ�ġ�� �ʰ��߽��ϴ�!");
            }
        }
        else
        {
            Debug.LogWarning("Ÿ���� ���õ��� �ʾҽ��ϴ�!");
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
                Debug.LogWarning($"[Ÿ�� {selectedTower.name}] ���ݼӵ� ��� �ִ�ġ�� �ʰ��߽��ϴ�!");
            }
        }
        else
        {
            Debug.LogWarning("Ÿ���� ���õ��� �ʾҽ��ϴ�!");
        }
    }
}