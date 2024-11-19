using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage;
    private float speed = 5f;
    private Vector3 direction;
    private bool isPenetrating = false;

    public void Initialize(Vector3 direction, int damage, bool penetrating = false)
    {
        this.direction = direction.normalized;
        this.damage = damage;
        this.isPenetrating = penetrating;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (!isPenetrating)
        {
            // 스테이지 경계 확인
            if (IsOutOfStage())
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (!isPenetrating)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("StageBoundary"))
        {
            Destroy(gameObject);
        }
    }

    private bool IsOutOfStage()
    {
        // 간단한 스테이지 경계 체크 (필요시 수정)
        return transform.position.x < -10 || transform.position.x > 10 || transform.position.y < -10 || transform.position.y > 10;
    }
}