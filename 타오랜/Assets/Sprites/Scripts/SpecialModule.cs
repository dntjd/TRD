using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialModule : MonoBehaviour
{
    public string moduleName = "Basic Module"; // 모듈 이름
    public string moduleDescription = "This is a special module."; // 모듈 설명
    public float moduleEffectDuration = 10f; // 효과 지속 시간
    public float cooldown = 5f; // 쿨다운 시간
    private float effectTimer = 0f; // 효과 타이머
    private bool isEffectActive = false; // 모듈 효과 활성화 상태

    private Tower attachedTower; // 이 모듈이 장착될 타워

    void Start()
    {
        // 모듈이 장착될 타워를 찾기
        attachedTower = GetComponent<Tower>();
    }

    // 특수 모듈 효과 시작
    public void ActivateModule()
    {
        if (!isEffectActive)
        {
            isEffectActive = true;
            effectTimer = moduleEffectDuration;
            ApplyModuleEffect();
            Debug.Log(moduleName + " 모듈이 활성화되었습니다!");
        }
        else
        {
            Debug.Log(moduleName + " 모듈은 이미 활성화되어 있습니다.");
        }
    }

    // 특수 모듈 효과 적용 (예시: 타워의 공격 방식을 변경)
    void ApplyModuleEffect()
    {
        if (attachedTower != null)
        {
            // 예시: 공격력 증가
            attachedTower.attackPower *= 2; // 모듈이 활성화되면 공격력 두 배
        }
    }

    void Update()
    {
        if (isEffectActive)
        {
            effectTimer -= Time.deltaTime;
            if (effectTimer <= 0)
            {
                DeactivateModule(); // 효과 지속 시간이 끝나면 비활성화
            }
        }
    }

    // 특수 모듈 효과 종료
    void DeactivateModule()
    {
        if (attachedTower != null)
        {
            // 예시: 공격력 원상복구
            attachedTower.attackPower /= 2;
        }
        isEffectActive = false;
        Debug.Log(moduleName + " 모듈 효과가 종료되었습니다.");
    }
}
