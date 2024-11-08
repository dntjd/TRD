using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private PlayerGold playerGold;
    [SerializeField]
    private int towerBuildGold = 50;

    public void SpawnTower(Transform tileTransform) {
        if (towerBuildGold > playerGold.CurrentGold) {
            return;
        }
        Tile tile = tileTransform.GetComponent<tile>();

        if (tile.IsBuildTower == true) {
            return;
        }
        tile.IsBuildTower = true;
        playerGold.CurrentGold -= towerBuildGold;
        GameObject clone = Instantiate(towerPrefab, tileTransform.position,Quaternion.identity);
        clone.GetComponent<Tower>().Setup(enemySpawner);
    }
}
