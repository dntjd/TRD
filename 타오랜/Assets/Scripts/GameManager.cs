using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Lobby, Playing, Paused, GameOver }
    public GameState currentState;

    void Start()
    {
        ChangeState(GameState.Lobby);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case GameState.Lobby:
                // 로비 UI 표시
                break;
            case GameState.Playing:
                // 게임 시작 설정
                break;
            case GameState.Paused:
                // 일시정지 설정
                break;
            case GameState.GameOver:
                // 게임 종료 처리
                break;
        }
    }
}
