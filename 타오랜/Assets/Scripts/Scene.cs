using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    // 스테이지 씬 이름을 지정합니다.
    public string stageSceneName = "LobbyScene";

    // 버튼 클릭 이벤트로 연결되는 함수
    public void LoadStageScene()
    {
        SceneManager.LoadScene(stageSceneName);
    }
}