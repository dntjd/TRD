using UnityEngine;

public class ShopButtonClickHandler : MonoBehaviour
{
    // 비활성화할 Main_UI 캔버스
    public GameObject mainUI;

    // 활성화할 Shop_UI 캔버스
    public GameObject shopUI;

    // Shop_Button에 연결된 메서드
    public void OnShopButtonClick()
    {
        // Main_UI 비활성화
        if (mainUI != null)
        {
            mainUI.SetActive(false);
        }

        // Shop_UI 활성화
        if (shopUI != null)
        {
            shopUI.SetActive(true);
        }
    }
}
