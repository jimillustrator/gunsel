using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //Variable of transform type to indicate where the enemy attack is going to happen
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        Debug.Log("bang bang");
    }

}
