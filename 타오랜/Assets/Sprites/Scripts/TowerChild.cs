using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface Attact
{
    public GameObject projectPrefab;//�߻�ü ���
    public Transform attackstart;//�߻�ü �߻� ��ġ
    public int attackPowe; // Ÿ�� ���ݷ�
    public float attackRate ;// ���� �ӵ�
    public float attackRange; // ���� ����
    public void attact();
}

public class TowerChild : MonoBehaviour, Attact
{
    // Start is called before the first frame update

    public void attact()
    {
        // Ÿ���� ���� ó�� �Լ�
    }

    void Awake()
    {
        //Ÿ�� ������ ���� ���� ����
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
