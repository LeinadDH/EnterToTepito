using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    private Transform _target;
    private NavMeshAgent _navMeshAgent;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _target = GameObject.FindWithTag("Player").transform;
    }
    
    private void Update()
    {
        _navMeshAgent.SetDestination(_target.position);
    }
}
