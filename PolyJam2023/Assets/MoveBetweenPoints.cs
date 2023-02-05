using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveBetweenPoints : MonoBehaviour
{
    public bool UseMovement;
    public Transform positionA;
    public Transform positionB;
    public bool MoveBack;
    public NavMeshAgent Object;
    public Animator animatorObject;

    // Start is called before the first frame update
    void Start()
    {
        if(UseMovement == true)
        {
            animatorObject.SetTrigger("AllowRun");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(UseMovement == true)
        {
            Move();
        }
    }
    void Move()
    {
        if (MoveBack == true)
        {
            Object.SetDestination(positionA.position);
            if(!Object.pathPending)
            {
                if(Object.remainingDistance<= Object.stoppingDistance)
                {
                    Object.SetDestination(positionB.position);
                    MoveBack = false;
                }
            }
        }
        else
        {
            Object.SetDestination(positionB.position);
            if(!Object.pathPending)
            {
                if(Object.remainingDistance<= Object.stoppingDistance)
                {
                    MoveBack = true;
                }
            }
        }
    }
}
