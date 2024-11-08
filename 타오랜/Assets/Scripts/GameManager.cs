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
                // �κ� UI ǥ��
                break;
            case GameState.Playing:
                // ���� ���� ����
                break;
            case GameState.Paused:
                // �Ͻ����� ����
                break;
            case GameState.GameOver:
                // ���� ���� ó��
                break;
        }
    }
}
