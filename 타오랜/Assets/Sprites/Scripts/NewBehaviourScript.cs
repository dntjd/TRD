using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    

    public void Use(Upgrade upgrade, Tower tower)
    {
        upgrade.Upgrade(tower);
    }
}
