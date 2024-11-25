using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
<<<<<<< Updated upstream
    public bool IsBuildTower { set; get; }
    private void Awake() {
        IsBuildTower = false;
=======
    bool IsBuildTower;
    enum ColliderType { tower, tower2, tower3};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
>>>>>>> Stashed changes
    }
}
