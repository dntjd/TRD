using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health = 30f; // 적의 체력
    private float currenthealth;
    
    public float speed = 2f; // 이동 속도
    
    private int         wayPointCount;      //이동 경로 개수
    private Transform[] wayPoints;          //이동할 경로 정보
    private int         currentIndex = 0;   //현재 목표지점 인덱스
    private Movement2D movement2D;
    private EnemySpawner enemySpawner;
    private SpriteRenderer spriteRenderer;

    public void Awake()
    {
        currenthealth = health;
       Enemy enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Setup(EnemySpawner enemySpawner,Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;

        //적 이동 경로 wayPoints 정보 설정
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        //적의 위치를 첫번째 wayPoints 위치로 설정
        transform.position = wayPoints[currentIndex].position;

        //적 이동/목표지점 설정 코루틴 함수 시작
        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        //다음 이동 방향 설정
        NextMoveTo();

        while (true) {
            //적 오브젝트 회전
            transform.Rotate(Vector3.forward * 10);

            //적의 현재위치와 목표위치의 거리가 0.02 * movement2D.MoveSpeed보다 작을 때 if문 실행
            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {
                //다음 이동 방향 설정
                NextMoveTo();
            }
            //movement2D.MoveSpeed를 곱해주는 이유: 속도가 빠르면 한 프레임에 0.02보다 크게 움직이기 때문에
            //if조건문에 걸리지 않고 경로를 탈주하는 오브젝트가 발생할 수 있기 때문이다
            yield return null;
        }
    }

    private void NextMoveTo()
    {
        //아직 이동할 wayPoints가 남아있다면
        if( currentIndex < wayPointCount - 1)
        {
            //적의 위치를 정확하게 목표 위치로 설정
            transform.position = wayPoints[currentIndex].position;
            //이동 방향 설정 => 다음 목표지점(wayPoints)
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position-transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else
        {
            //적 오브젝트 삭제
            Destroy(gameObject);
        }
    }
    // 피해를 입는 메서드
    public void TakeDamage(float damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            Die();
        }
    }

    // 적이 죽었을 때 처리
    private void Die()
    {
        enemySpawner.DieEnemy(this);
        // 적이 죽을 때 보상 처리 등을 추가 가능
    }
}
