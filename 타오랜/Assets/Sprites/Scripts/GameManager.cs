using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Lobby, Playing, Paused, GameOver }
    public GameState currentState;

    public UIManager uiManager; // UI �Ŵ��� ����
    public Stage stage; // �������� ����
    public GameObject towerPrefab; // Ÿ�� ������
    public Transform towerParent; // Ÿ���� ��ġ�� �θ� ��ü
    public float towerPlacementCost = 50f; // Ÿ�� ��ġ ���

    private float playerResources = 100f; // �÷��̾� �ڿ� (Ÿ���� ��ġ�� �� ���)
    private List<Tower> towers = new List<Tower>(); // ��ġ�� Ÿ�� ����Ʈ
    
    void Start()
    {
        ChangeState(GameState.Lobby);
    }

    // ���� ���� ����
    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case GameState.Lobby:
                uiManager.ShowLobby();
                break;
            case GameState.Playing:
                uiManager.StartGame();
                StartGame();
                break;
            case GameState.Paused:
                uiManager.ShowSettings(); // �Ͻ����� UI�� ������
                break;
            case GameState.GameOver:
                uiManager.ShowGameOver(); // ���� ���� UI�� ������
                break;
        }
    }

    // ���� ���� �� �ʱ�ȭ
    public void StartGame()
    {
        stage.StartWave();
        // ������ ���۵Ǹ� ���� �����ϰ� Ÿ�� ��ġ�� ������ �� �ְ� ��
    }

    // ������ �Ͻ�����
    public void PauseGame()
    {
        ChangeState(GameState.Paused);
    }

    // ������ ����
    public void EndGame()
    {
        ChangeState(GameState.GameOver);
    }

    // Ÿ�� ��ġ (�÷��̾ Ÿ���� ��ġ�Ϸ��� �� �� ȣ��)
    public void PlaceTower(Vector2 position)
    {
        if (currentState == GameState.Playing && playerResources >= towerPlacementCost)
        {
            GameObject newTower = Instantiate(towerPrefab, position, Quaternion.identity, towerParent);
            Tower towerScript = newTower.GetComponent<Tower>();
            towers.Add(towerScript);
            playerResources -= towerPlacementCost; // �ڿ� ����
            Debug.Log("Ÿ�� ��ġ �Ϸ�! ���� �ڿ�: " + playerResources);
        }
        else if (playerResources < towerPlacementCost)
        {
            Debug.Log("�ڿ��� �����մϴ�!");
        }
    }

    // Ÿ�� ���׷��̵� (����)
    public void UpgradeTower(Tower tower)
    {
        if (playerResources >= tower.upgradeCost) // ���׷��̵� ����� �ڿ����� ���� ���
        {
            playerResources -= tower.upgradeCost;
            tower.Upgrade();
            Debug.Log("Ÿ�� ���׷��̵� �Ϸ�! ���� �ڿ�: " + playerResources);
        }
        else
        {
            Debug.Log("�ڿ��� �����Ͽ� ���׷��̵��� �� �����ϴ�.");
        }
    }

    // �ڿ� �߰� (�� óġ ������ �ڿ� ���)
    public void AddResources(float amount)
    {
        playerResources += amount;
        Debug.Log("�ڿ� ȹ��! ���� �ڿ�: " + playerResources);
    }
}
