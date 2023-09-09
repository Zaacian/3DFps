using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed = 15f, lifeTime = 5f;
    public Rigidbody rb;

    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = transform.forward * moveSpeed;
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
            Destroy(gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position + (transform.forward * (-moveSpeed *

        Time.deltaTime)), transform.rotation);
    }
}
