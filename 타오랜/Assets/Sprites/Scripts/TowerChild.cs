using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface Attact
{
    public GameObject projectPrefab;//발사체 모양
    public Transform attackstart;//발사체 발사 위치
    public int attackPowe; // 타워 공격력
    public float attackRate ;// 공격 속도
    public float attackRange; // 공격 범위
    public void attact();
}

public class TowerChild : MonoBehaviour, Attact
{
    // Start is called before the first frame update

    public void attact()
    {
        // 타워별 공격 처리 함수
    }

    void Awake()
    {
        //타워 공격을 위한 변수 지정
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
