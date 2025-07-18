using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieController : MonoBehaviour
{
    public NavMeshAgent navAgent;

    [SerializeField] public Transform targetTransform;

    public void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        if (targetTransform == null)
        {
            Debug.LogWarning("ZombieController: Target Transform is not assigned.");
        }
    }

    public void Update()
    {
        if (navAgent != null && targetTransform != null)
        {
            navAgent.SetDestination(targetTransform.position);
        }
    }
}
