using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialModule : MonoBehaviour
{
    public string moduleName = "Basic Module"; // ��� �̸�
    public string moduleDescription = "This is a special module."; // ��� ����
    public float moduleEffectDuration = 10f; // ȿ�� ���� �ð�
    public float cooldown = 5f; // ��ٿ� �ð�
    private float effectTimer = 0f; // ȿ�� Ÿ�̸�
    private bool isEffectActive = false; // ��� ȿ�� Ȱ��ȭ ����

    private Tower attachedTower; // �� ����� ������ Ÿ��

    void Start()
    {
        // ����� ������ Ÿ���� ã��
        attachedTower = GetComponent<Tower>();
    }

    // Ư�� ��� ȿ�� ����
    public void ActivateModule()
    {
        if (!isEffectActive)
        {
            isEffectActive = true;
            effectTimer = moduleEffectDuration;
            ApplyModuleEffect();
            Debug.Log(moduleName + " ����� Ȱ��ȭ�Ǿ����ϴ�!");
        }
        else
        {
            Debug.Log(moduleName + " ����� �̹� Ȱ��ȭ�Ǿ� �ֽ��ϴ�.");
        }
    }

    // Ư�� ��� ȿ�� ���� (����: Ÿ���� ���� ����� ����)
    void ApplyModuleEffect()
    {
        if (attachedTower != null)
        {
            // ����: ���ݷ� ����
            attachedTower.attackPower *= 2; // ����� Ȱ��ȭ�Ǹ� ���ݷ� �� ��
        }
    }

    void Update()
    {
        if (isEffectActive)
        {
            effectTimer -= Time.deltaTime;
            if (effectTimer <= 0)
            {
                DeactivateModule(); // ȿ�� ���� �ð��� ������ ��Ȱ��ȭ
            }
        }
    }

    // Ư�� ��� ȿ�� ����
    void DeactivateModule()
    {
        if (attachedTower != null)
        {
            // ����: ���ݷ� ���󺹱�
            attachedTower.attackPower /= 2;
        }
        isEffectActive = false;
        Debug.Log(moduleName + " ��� ȿ���� ����Ǿ����ϴ�.");
    }
}
