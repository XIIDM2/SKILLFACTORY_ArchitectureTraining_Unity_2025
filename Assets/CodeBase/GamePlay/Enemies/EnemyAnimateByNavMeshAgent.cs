using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.GamePlay.Enemies
{
    public class EnemyAnimateByNavMeshAgent : MonoBehaviour
    {
        private const float MovementTreshHold = 0.05f;

        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private EnemyAnimator animator;

        private void Update()
        {
            animator.SetMove(navMeshAgent.velocity.magnitude >= MovementTreshHold);
        }
    }
}