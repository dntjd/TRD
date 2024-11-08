using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // ���� ü��
    public float speed = 2f; // �̵� �ӵ�
    private Transform[] path; // �̵��� ���
    private int currentPathIndex = 0;

    // ��� ����
    public void SetPath(Transform[] path)
    {
        this.path = path;
        transform.position = path[0].position;
    }

    void Update()
    {
        MoveAlongPath();
    }

    // ��θ� ���� �̵�
    private void MoveAlongPath()
    {
        if (currentPathIndex < path.Length)
        {
            Vector3 targetPosition = path[currentPathIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentPathIndex++;
            }
        }
        else
        {
            ReachEnd();
        }
    }

    // ��� �������� �������� �� ó��
    private void ReachEnd()
    {
        Destroy(gameObject); // ���⼭�� �ܼ��� �ı�������, ���� �� �÷��̾�� ���ظ� �� ���� ����.
    }

    // ���ظ� �Դ� �޼���
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // ���� �׾��� �� ó��
    private void Die()
    {
        Destroy(gameObject);
        // ���� ���� �� ���� ó�� ���� �߰� ����
    }
}
