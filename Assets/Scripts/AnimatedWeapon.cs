using System.Collections;
using UnityEngine;

public class AnimatedWeapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] GameObject muzzleFlash2D;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;

    Animator myAnimator;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Start()
    {
        muzzleFlash2D.GetComponent<MeshRenderer>().enabled = false;
        myAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            RotateMuzzleFlash();
            myAnimator.SetTrigger("active");
            StartCoroutine(ShowMuzzleFlash());
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            //CreateHitImpact(hit);
            StartCoroutine(CreateHitImpact(hit));
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }



    //private void CreateHitImpact(RaycastHit hit)
    //{
    //    GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
    //    Destroy(impact, .1f);
    //}

    private IEnumerator CreateHitImpact(RaycastHit hit)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

    private IEnumerator ShowMuzzleFlash()
    {
        yield return new WaitForSecondsRealtime(0.23f);
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
