using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    NavMeshAgent nm;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        nm.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
