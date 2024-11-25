using UnityEngine;

public class StageButtonClickHandler : MonoBehaviour
{
    // 비활성화할 Main_UI 캔버스
    public GameObject mainUI;

    // 활성화할 Stage_Sellect_UI 캔버스
    public GameObject stageSelectUI;

    // Stage_Button에 연결된 메서드
    public void OnStageButtonClick()
    {
        // Main_UI 비활성화
        if (mainUI != null)
        {
            mainUI.SetActive(false);
        }

        // Stage_Sellect_UI 활성화
        if (stageSelectUI != null)
        {
            stageSelectUI.SetActive(true);
        }
    }
}
