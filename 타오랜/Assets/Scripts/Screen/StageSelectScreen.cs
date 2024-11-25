using UnityEngine;

public class StageButtonClickHandler : MonoBehaviour
{
    // ��Ȱ��ȭ�� Main_UI ĵ����
    public GameObject mainUI;

    // Ȱ��ȭ�� Stage_Sellect_UI ĵ����
    public GameObject stageSelectUI;

    // Stage_Button�� ����� �޼���
    public void OnStageButtonClick()
    {
        // Main_UI ��Ȱ��ȭ
        if (mainUI != null)
        {
            mainUI.SetActive(false);
        }

        // Stage_Sellect_UI Ȱ��ȭ
        if (stageSelectUI != null)
        {
            stageSelectUI.SetActive(true);
        }
    }
}
