using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage;
    private float speed = 5f;
    private Transform target; // ��ǥ ��
    private bool isPenetrating = false;
    private bool isAoE = false;
    private bool isSlowing = false; // ��ȭ ��ž Ȱ��ȭ ����

    private float aoeDuration = 5f; // ���� ���� �ð�
    private float damageInterval = 1f; // ������ �ֱ�
    private float aoeRange = 2.5f; // ���� ����
    private float aoeTimer = 0f; // ������ ���� Ÿ�̸�
    private float lifetimeTimer = 0f; // ���� ��ü ���ӽð� Ÿ�̸�

    public void Initialize(Transform target, int damage, bool penetrating = false, bool aoe = false, bool slowing = false, float aoeRange = 2.5f, float aoeDuration = 5f, float damageInterval = 1f)
    {
        this.target = target;
        this.damage = damage;
        this.isPenetrating = penetrating;
        this.isAoE = aoe;
        this.isSlowing = slowing; // ��ȭ ��ž ���� ����

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
            // ���� ���� �ð� ����
            lifetimeTimer += Time.deltaTime;

            if (lifetimeTimer >= aoeDuration)
            {
                Destroy(gameObject);
                return;
            }

            // �ֱ������� ������ ����
            aoeTimer += Time.deltaTime;
            if (aoeTimer >= damageInterval)
            {
                aoeTimer = 0f;
                ApplyAoEDamage();
            }
        }
        else if (target != null)
        {
            // ���� ���� �̵�
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // ���� �浹 üũ
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                OnHit();
            }
        }
        else
        {
            // Ÿ���� ������� ��� �ı�
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
            // AoE ���� Ȱ��ȭ
            ActivateAoE();
        }
        else
        {
            // �Ϲ� ����ü ������ ó��
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                if (isSlowing)
                {
                    // ��ȭ ��ž�� ������ ���
                    //enemy.SlowDown(0.5f); // 50% �ӵ� ����
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
        speed = 0f; // �������� ��ȯ

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