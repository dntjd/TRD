using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    // �������� �� �̸��� �����մϴ�.
    public string stageSceneName = "TitleScene";

    // ��ư Ŭ�� �̺�Ʈ�� ����Ǵ� �Լ�
    public void LoadStageScene()
    {
        SceneManager.LoadScene(stageSceneName);
    }
}