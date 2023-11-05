using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //Variable of PlayerHealth type because the C# script PlayerHealth created the type
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        //Okay to put "FindObjectOfType" in Start() but not in Update()
        target = FindObjectOfType<PlayerHealth>(); 
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        //target already has TakeDamage component because it was initialized in Start()
        target.TakeDamage(damage);
    }

}
