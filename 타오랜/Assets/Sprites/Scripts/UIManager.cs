using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject lobbyUI;
    public GameObject shopUI;
    public GameObject settingsUI;

    // �κ� UI�� ǥ��
    public void ShowLobby()
    {
        lobbyUI.SetActive(true);
        shopUI.SetActive(false);
        settingsUI.SetActive(false);
    }

    // ���� UI�� ǥ��
    public void ShowShop()
    {
        shopUI.SetActive(true);
        lobbyUI.SetActive(false);
        settingsUI.SetActive(false);
    }

    // ���� UI�� ǥ��
    public void ShowSettings()
    {
        settingsUI.SetActive(true);
        lobbyUI.SetActive(false);
        shopUI.SetActive(false);
    }

    //UI���� ��������
    public void StartGame()
    {
        lobbyUI.SetActive(false);
        shopUI.SetActive(false);
        settingsUI.SetActive(false);
    }
}
