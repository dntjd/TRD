using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Lobby, Playing, Paused, GameOver }
    public GameState currentState;

    public UIManager uiManager; // UI 매니저 참조
    public Stage stage; // 스테이지 관리
    public GameObject towerPrefab; // 타워 프리팹
    public Transform towerParent; // 타워를 배치할 부모 객체
    public float towerPlacementCost = 50f; // 타워 배치 비용

    private float playerResources = 100f; // 플레이어 자원 (타워를 배치할 때 사용)
    private List<Tower> towers = new List<Tower>(); // 배치된 타워 리스트
    
    void Start()
    {
        ChangeState(GameState.Lobby);
    }

    // 게임 상태 변경
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
                uiManager.ShowSettings(); // 일시정지 UI를 보여줌
                break;
            case GameState.GameOver:
                uiManager.ShowGameOver(); // 게임 오버 UI를 보여줌
                break;
        }
    }

    // 게임 시작 시 초기화
    public void StartGame()
    {
        stage.StartWave();
        // 게임이 시작되면 적을 생성하고 타워 배치를 시작할 수 있게 함
    }

    // 게임을 일시정지
    public void PauseGame()
    {
        ChangeState(GameState.Paused);
    }

    // 게임을 종료
    public void EndGame()
    {
        ChangeState(GameState.GameOver);
    }

    // 타워 배치 (플레이어가 타워를 배치하려고 할 때 호출)
    public void PlaceTower(Vector2 position)
    {
        if (currentState == GameState.Playing && playerResources >= towerPlacementCost)
        {
            GameObject newTower = Instantiate(towerPrefab, position, Quaternion.identity, towerParent);
            Tower towerScript = newTower.GetComponent<Tower>();
            towers.Add(towerScript);
            playerResources -= towerPlacementCost; // 자원 차감
            Debug.Log("타워 배치 완료! 남은 자원: " + playerResources);
        }
        else if (playerResources < towerPlacementCost)
        {
            Debug.Log("자원이 부족합니다!");
        }
    }

    // 타워 업그레이드 (예시)
    public void UpgradeTower(Tower tower)
    {
        if (playerResources >= tower.upgradeCost) // 업그레이드 비용이 자원보다 적을 경우
        {
            playerResources -= tower.upgradeCost;
            tower.Upgrade();
            Debug.Log("타워 업그레이드 완료! 남은 자원: " + playerResources);
        }
        else
        {
            Debug.Log("자원이 부족하여 업그레이드할 수 없습니다.");
        }
    }

    // 자원 추가 (적 처치 등으로 자원 얻기)
    public void AddResources(float amount)
    {
        playerResources += amount;
        Debug.Log("자원 획득! 현재 자원: " + playerResources);
    }
}
