using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private Movement2D movement2D;
    private Transform target;

    // Start is called before the first frame update
    public void Setup(Transform target)
    {
        movement2D = GetComponent<Movement2D>();
        this.target = target;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
