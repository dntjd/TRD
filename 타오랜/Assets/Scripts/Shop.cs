using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

// 타워를 구매했을 때 타워 오브젝트를 복제하여 선택한 위치에 생성
public class Purchase_Tower : MonoBehaviour
{
    public GameObject Tower;
    void Tower_Purachase()
    {
        GameObject tower = (GameObject)Instantiate(Tower, new Vector3(), Quaternion.identity);   // Vector3의 ()안에 들어가는 게 좌표, identity자리가 개체의 각도
    }
}

// 업그레이드를 구매했을 때 데이터 상 존재하는 모든 타워의 능력치 향상
public class Purchase_Upgrade : MonoBehaviour
{
    public Purchase_Upgrade tower;
    
}