using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage;
    private float speed = 5f;
    private Transform target; // 목표 적
    private bool isPenetrating = false;
    private bool isAoE = false;
    private bool isSlowing = false; // 둔화 포탑 활성화 여부

    private float aoeDuration = 5f; // 장판 지속 시간
    private float damageInterval = 1f; // 데미지 주기
    private float aoeRange = 2.5f; // 장판 범위
    private float aoeTimer = 0f; // 데미지 간격 타이머
    private float lifetimeTimer = 0f; // 장판 전체 지속시간 타이머

    public void Initialize(Transform target, int damage, bool penetrating = false, bool aoe = false, bool slowing = false, float aoeRange = 2.5f, float aoeDuration = 5f, float damageInterval = 1f)
    {
        this.target = target;
        this.damage = damage;
        this.isPenetrating = penetrating;
        this.isAoE = aoe;
        this.isSlowing = slowing; // 둔화 포탑 적용 여부

        if (isAoE)
        {
            this.aoeRange = aoeRange;
            this.aoeDuration = aoeDuration;
            this.damageInterval = damageInterval;
        }
    }

    private void Update()
    {
        if (isAoE && speed == 0f)
        {
            // 장판 지속 시간 관리
            lifetimeTimer += Time.deltaTime;

            if (lifetimeTimer >= aoeDuration)
            {
                Destroy(gameObject);
                return;
            }

            // 주기적으로 데미지 적용
            aoeTimer += Time.deltaTime;
            if (aoeTimer >= damageInterval)
            {
                aoeTimer = 0f;
                ApplyAoEDamage();
            }
        }
        else if (target != null)
        {
            // 적을 향해 이동
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // 적과 충돌 체크
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                OnHit();
            }
        }
        else
        {
            // 타겟이 사라졌을 경우 파괴
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && collision.transform == target)
        {
            OnHit();
        }
    }

    private void OnHit()
    {
        if (isAoE)
        {
            // AoE 장판 활성화
            ActivateAoE();
        }
        else
        {
            // 일반 투사체 데미지 처리
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                if (isSlowing)
                {
                    // 둔화 포탑이 공격한 경우
                    //enemy.SlowDown(0.5f); // 50% 속도 감소
                }
            }

            if (!isPenetrating)
            {
                Destroy(gameObject);
            }
        }
    }

    private void ActivateAoE()
    {
        speed = 0f; // 장판으로 전환

        ApplyAoEDamage();
        transform.localScale = Vector3.one * aoeRange * 2;
    }

    private void ApplyAoEDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, aoeRange);
        foreach (Collider2D collider in enemies)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}