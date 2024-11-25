using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject lobbyUI;
    public GameObject shopUI;
    public GameObject settingsUI;

    // 로비 UI를 표시
    public void ShowLobby()
    {
        lobbyUI.SetActive(true);
        shopUI.SetActive(false);
        settingsUI.SetActive(false);
    }

    // 상점 UI를 표시
    public void ShowShop()
    {
        shopUI.SetActive(true);
        lobbyUI.SetActive(false);
        settingsUI.SetActive(false);
    }

    // 설정 UI를 표시
    public void ShowSettings()
    {
        settingsUI.SetActive(true);
        lobbyUI.SetActive(false);
        shopUI.SetActive(false);
    }

    //UI끄고 게임진행
    public void StartGame()
    {
        lobbyUI.SetActive(false);
        shopUI.SetActive(false);
        settingsUI.SetActive(false);
    }
}
