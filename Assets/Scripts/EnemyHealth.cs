using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] float deathPause = 0.3f;

    bool isDead = false;

    //Getter method 
    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(isDead)
        {
            return;
        }
        isDead = true;
        //GetComponent<Animator>().SetTrigger("death");
        StartCoroutine(DeathDelay());
    }

    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(deathPause);
        GetComponent<Animator>().SetTrigger("death");
    }
}
