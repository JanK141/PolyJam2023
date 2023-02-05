using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] float HP;
    [SerializeField] float damagePerHit;
    [SerializeField] float AttackInterval;

    private Animator animator;
    private NavMeshAgent agent;
    private Grow target;

    public Spawner Spawner { get; set; }
    public float Health { get; set; }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        Health = HP;
    }

    void Start()
    {
        StartCoroutine(Cycle());
    }

    private Grow FindNearest()
    {
        return FindObjectsOfType<Grow>().Aggregate((min, next) =>
        Vector3.Distance(transform.position, min.transform.position) < Vector3.Distance(transform.position, next.transform.position) ?
        min : next);
    }

    IEnumerator Cycle()
    {
        while (true)
        {
            target = FindNearest();
            agent.SetDestination(target.transform.position);

            if(animator != null && animator.isActiveAndEnabled)
            {
                if (!animator.GetBool("IsRunning"))
                {
                    animator.SetBool("IsRunning", true);
                }

                if (animator.GetBool("IsAttacking"))
                {
                    animator.SetBool("IsAttacking", false);
                }
            }

            

            yield return new WaitUntil(() => agent.remainingDistance < 5);

            if(animator != null && animator.isActiveAndEnabled)
            {
                if (animator.GetBool("IsRunning"))
                {
                    animator.SetBool("IsRunning", false);
                }

                if (!animator.GetBool("IsAttacking"))
                {
                    animator.SetBool("IsAttacking", true);
                }
            }

            while (target != null)
            {
                target.ReceiveHit();

                if(target.Health <= 0)
                {
                    if (animator != null && animator.isActiveAndEnabled)
                    {
                        if (!animator.GetBool("IsRunning"))
                        {
                            animator.SetBool("IsRunning", true);
                        }

                        if (animator.GetBool("IsAttacking"))
                        {
                            animator.SetBool("IsAttacking", false);
                        }
                    }
                }


                yield return new WaitForSeconds(AttackInterval);
            }
        }
    }

    public void ReceiveHit()
    {
        Health -= damagePerHit;
        transform.DOShakePosition(0.2f);

        if(Health <= 0)
        {
            Spawner.enemiesSpawned.Remove(this);

            Destroy(gameObject, 0.1f);
        }
    }
}
