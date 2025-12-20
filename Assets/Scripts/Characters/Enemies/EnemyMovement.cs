using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemies
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
    public class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
    }
}
