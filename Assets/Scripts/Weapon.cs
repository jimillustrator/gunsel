using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] GameObject muzzleFlash2D;
    [SerializeField] GameObject hitEffect;
    [SerializeField] int bulletAmount = 6;
    [SerializeField] float timeBetweenShots = 0.5f;

    bool canShoot = true;

    private void Start()
    {
        muzzleFlash2D.GetComponent<MeshRenderer>().enabled = false;
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (bulletAmount > 0)
        {
            RotateMuzzleFlash();
            StartCoroutine(ShowMuzzleFlash());
            ProcessRaycast();
            bulletAmount = bulletAmount - 1;
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

    private IEnumerator ShowMuzzleFlash()
    {
        muzzleFlash2D.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSecondsRealtime(0.03f);
        muzzleFlash2D.GetComponent<MeshRenderer>().enabled = false;
    }

    private void RotateMuzzleFlash()
    {
        float muzzleRotation = Random.Range(0, 90);
        muzzleFlash2D.transform.Rotate(0.0f, muzzleRotation, 0.0f, Space.Self);
    }
}
