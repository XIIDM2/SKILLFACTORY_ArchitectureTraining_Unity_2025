using Assets.CodeBase.Infrustructure.DependencyInjection;
using CodeBase.GamePlay.Enemies;
using CodeBase.Infrastructure.Services.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.GamePlay.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyID enemyID;
        private IGameFactory gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        public void SpawnBoxerEnemy()
        {
            gameFactory.CreateEnemy(enemyID, transform.position);
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
#endif
    }
}