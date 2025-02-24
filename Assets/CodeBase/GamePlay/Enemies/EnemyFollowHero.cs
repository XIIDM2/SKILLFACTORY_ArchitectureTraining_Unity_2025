using Assets.CodeBase.Infrustructure.DependencyInjection;
using CodeBase.Infrastructure.Services.Factory;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.GamePlay.Enemies
{
    public class EnemyFollowHero : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float stoppingDistance;
        [SerializeField] private NavMeshAgent navMeshAgent;

        private IGameFactory gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        private void Start()
        {
            navMeshAgent.speed = movementSpeed;
            navMeshAgent.stoppingDistance = stoppingDistance;
            navMeshAgent.Warp(transform.position);
        }

        private void Update()
        {
            if (!gameFactory.HeroObject) return;

            if (Vector3.Distance(transform.position, gameFactory.HeroObject.transform.position) <= stoppingDistance) return;

            navMeshAgent.destination = gameFactory.HeroObject.transform.position;
        }
    }
}