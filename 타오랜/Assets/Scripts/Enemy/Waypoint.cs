using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public static Waypoint Instance; // 싱글턴 패턴

    [SerializeField]
    private Transform[] waypoints; // 경로에 있는 모든 웨이포인트
    [SerializeField]
    private Transform[] startWaypoints; // 시작 웨이포인트 배열

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
    /// 특정 인덱스의 웨이포인트 반환
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
    /// 웨이포인트 총 개수 반환
    /// </summary>
    public int GetWaypointCount()
    {
        return waypoints.Length;
    }

    /// <summary>
    /// 랜덤 시작 웨이포인트 반환
    /// </summary>
    public Transform GetRandomStartWaypoint()
    {
        if (startWaypoints.Length == 0) return null;
        int randomIndex = Random.Range(0, startWaypoints.Length);
        return startWaypoints[randomIndex];
    }
}
