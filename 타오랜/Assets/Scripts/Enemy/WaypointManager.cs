using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Instance; // �̱��� ����

    [SerializeField]
    private Transform[] waypoints; // ��ο� �ִ� ��� ��������Ʈ

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Ư�� �ε����� ��������Ʈ ��ȯ
    /// </summary>
    /// <param name="index">��������Ʈ �ε���</param>
    /// <returns>��������Ʈ ��ġ</returns>
    public Transform GetWaypoint(int index)
    {
        if (index < 0 || index >= waypoints.Length)
        {
            return null; // �ε��� �ʰ� �� null ��ȯ
        }
        return waypoints[index];
    }
}
