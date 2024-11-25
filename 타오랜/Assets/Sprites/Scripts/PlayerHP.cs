using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField]
    private float maxHP = 100;
    private float currentHP;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;


    
    private void Awake()
    {
        currentHP = maxHP;
    }

    public void Takedamage(float damage) { 
    currentHP -= damage;
        if (currentHP < 0) { 
            
        }
    }
=======
    int MaxHP;
    int CurrentHP;
>>>>>>> Stashed changes
}
