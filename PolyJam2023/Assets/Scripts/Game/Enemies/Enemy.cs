using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] float HP;
    [SerializeField] float damagePerHit;
    [SerializeField] float AttackInterval;

    private NavMeshAgent agent;
    private Grow target;

    public Spawner Spawner { get; set; }
    public float Health { get; set; }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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

            yield return new WaitUntil(() => agent.remainingDistance < 5);

            while (target != null)
            {
                target.ReceiveHit();
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
            this.Spawner.enemiesSpawned.Remove(this);
            Destroy(this.gameObject);
        }
    }
}
