using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent navMesh;
    public GameObject player;

    public float hpMummy = 10f;
    float distance;
    public float maxFollowDistance = 20f;
    public float DistanceToStop = 4f;

    public bool isWalk = false;
    public bool isDie = false;
    public bool isAttack = false;

    Animator enmeyAnimator;
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        enmeyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpMummy > 0)
        {
            Seeking();

        }
        else
        {
            Dead();
        }
        // navMesh.SetDestination(player.transform.position);
        print(distance);
        enmeyAnimator.SetBool("isWalk", isWalk);
        enmeyAnimator.SetBool("isDie", isDie);
        enmeyAnimator.SetBool("isAttack", isAttack);
    }

    void Seeking()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > DistanceToStop && distance < maxFollowDistance) // ??????????????
        {
            navMesh.SetDestination(player.transform.position);
            isWalk = true;
            isAttack = false;
        }
        else
        {
            navMesh.SetDestination(transform.position);
            isWalk = false;
            if (distance < DistanceToStop)
            {
                isAttack = true;
                if (PlayerHealth.instance.checkDamageScreen == false)
                {

                    StartCoroutine(PlayerHealth.instance.delayDamageScreen());

                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hpMummy -= 1;
            print(hpMummy);

            if (hpMummy > 0)
            {
                enmeyAnimator.Play("Z_Attack");
                StartCoroutine(flashEnemy());
            }
            if (hpMummy > 0)
            {
                enmeyAnimator.Play("Z_FallingBack");
                StartCoroutine(flashEnemy());
            }
        }
    }
    void Dead()
    {
        if (hpMummy < 1)
        {
            navMesh.isStopped = true;
            isDie = true;
            StartCoroutine(delayDead());
        }
    }
    IEnumerator delayDead()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    IEnumerator flashEnemy()
    {
        for (var n = 0; n < 5; n++)
        {
            material.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            material.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
