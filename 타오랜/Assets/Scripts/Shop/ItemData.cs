using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item_Data", menuName = "Scriptable Object/item_Data", order = int.MaxValue)]
//�����޴��ٿ� item_Data��� scriptableobject�� �����ϴ� �޴��� ����
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string item_name; // �������� �̸�
    public string Item_Name { get { return item_name; } }
    [SerializeField]
    private int price; // �������� ����
    public int Price { get { return price; } }
    [SerializeField]
    private int item_stat; // �������� ���� ������
    public int Item_Stat { get { return item_stat; } }
}