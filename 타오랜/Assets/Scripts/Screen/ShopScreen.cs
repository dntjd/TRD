using UnityEngine;

public class ShopButtonClickHandler : MonoBehaviour
{
    // ��Ȱ��ȭ�� Main_UI ĵ����
    public GameObject mainUI;

    // Ȱ��ȭ�� Shop_UI ĵ����
    public GameObject shopUI;

    // Shop_Button�� ����� �޼���
    public void OnShopButtonClick()
    {
        // Main_UI ��Ȱ��ȭ
        if (mainUI != null)
        {
            mainUI.SetActive(false);
        }

        // Shop_UI Ȱ��ȭ
        if (shopUI != null)
        {
            shopUI.SetActive(true);
        }
    }
}
