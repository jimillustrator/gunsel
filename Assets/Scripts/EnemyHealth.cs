using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            StartCoroutine(DelayDestroy());
        }
    }

    public IEnumerator DelayDestroy()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Destroy(gameObject);
    }
}
