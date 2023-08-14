using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] GameObject muzzleFlash2D;

    private void Start()
    {
        muzzleFlash2D.GetComponent<MeshRenderer>().enabled = false;
    }


    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        StartCoroutine(ShowMuzzleFlash());
        ProcessRaycast();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thing: " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private IEnumerator ShowMuzzleFlash()
    {
        muzzleFlash2D.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSecondsRealtime(0.03f);
        muzzleFlash2D.GetComponent<MeshRenderer>().enabled = false;
    }
}
