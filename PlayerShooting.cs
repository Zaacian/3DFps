using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public Transform transformCamera;
    public GameObject muzzleFlash;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            RaycastHit hit;
            if (Physics.Raycast(transformCamera.position,

            transformCamera.forward, out hit, 50f))

            {
                print(hit.transform.name);
                firePoint.LookAt(hit.point);
            }
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
        }
    }
}
