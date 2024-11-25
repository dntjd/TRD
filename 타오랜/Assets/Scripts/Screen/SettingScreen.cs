using UnityEngine;

public class SettingButtonClickHandler : MonoBehaviour
{
    // 활성화할 Setting_UI 캔버스
    public GameObject Setting_UI;

    // Setting_Button에 연결된 메서드
    public void OnSettingButtonClick()
    {
        // Setting_UI 활성화
        if (Setting_UI != null)
        {
            Setting_UI.SetActive(true);
        }
    }
}
