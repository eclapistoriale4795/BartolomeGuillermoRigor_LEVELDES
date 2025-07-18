using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{

    private NavMeshAgent agent = null;
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        GetReferences();
    }
    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }
    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
