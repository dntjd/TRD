using UnityEngine;

public class SettingButtonClickHandler : MonoBehaviour
{
    // Ȱ��ȭ�� Setting_UI ĵ����
    public GameObject Setting_UI;

    // Setting_Button�� ����� �޼���
    public void OnSettingButtonClick()
    {
        // Setting_UI Ȱ��ȭ
        if (Setting_UI != null)
        {
            Setting_UI.SetActive(true);
        }
    }
}
