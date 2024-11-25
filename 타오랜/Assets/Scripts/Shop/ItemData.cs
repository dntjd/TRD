using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item_Data", menuName = "Scriptable Object/item_Data", order = int.MaxValue)]
//생성메뉴바에 item_Data라는 scriptableobject를 생성하는 메뉴를 생성
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string item_name; // 아이템의 이름
    public string Item_Name { get { return item_name; } }
    [SerializeField]
    private int price; // 아이템의 가격
    public int Price { get { return price; } }
    [SerializeField]
    private int item_stat; // 아이템의 스텟 증가량
    public int Item_Stat { get { return item_stat; } }
}