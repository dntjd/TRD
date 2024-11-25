using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public static Waypoint Instance; // �̱��� ����

    [SerializeField]
    private Transform[] waypoints; // ��ο� �ִ� ��� ��������Ʈ
    [SerializeField]
    private Transform[] startWaypoints; // ���� ��������Ʈ �迭

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
    public Transform GetWaypoint(int index)
    {
        if (index >= 0 && index < waypoints.Length)
        {
            return waypoints[index];
        }
        return null;
    }

    /// <summary>
    /// ��������Ʈ �� ���� ��ȯ
    /// </summary>
    public int GetWaypointCount()
    {
        return waypoints.Length;
    }

    /// <summary>
    /// ���� ���� ��������Ʈ ��ȯ
    /// </summary>
    public Transform GetRandomStartWaypoint()
    {
        if (startWaypoints.Length == 0) return null;
        int randomIndex = Random.Range(0, startWaypoints.Length);
        return startWaypoints[randomIndex];
    }
}
