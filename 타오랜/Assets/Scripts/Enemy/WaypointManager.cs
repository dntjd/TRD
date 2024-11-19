using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Instance; // 싱글턴 패턴

    [SerializeField]
    private Transform[] waypoints; // 경로에 있는 모든 웨이포인트

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
    /// <param name="index">웨이포인트 인덱스</param>
    /// <returns>웨이포인트 위치</returns>
    public Transform GetWaypoint(int index)
    {
        if (index < 0 || index >= waypoints.Length)
        {
            return null; // 인덱스 초과 시 null 반환
        }
        return waypoints[index];
    }
}
