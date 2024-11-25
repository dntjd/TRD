using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    // �������� �� �̸��� �����մϴ�.
    public string stageSceneName = "LoobyScene";

    // ��ư Ŭ�� �̺�Ʈ�� ����Ǵ� �Լ�
    public void LoadStageScene()
    {
        SceneManager.LoadScene(stageSceneName);
    }
}
