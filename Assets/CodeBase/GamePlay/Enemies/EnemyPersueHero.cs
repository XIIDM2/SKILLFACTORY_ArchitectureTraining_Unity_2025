using Assets.CodeBase.Infrustructure.DependencyInjection;
using CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace CodeBase.GamePlay.Enemies
{
    public class EnemyPersueHero : MonoBehaviour
    {
        [SerializeField] private float radiusToSpotHero;

        private EnemyFollowHero enemyFollowHero;
        private IGameFactory gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        private void Start()
        {
            enemyFollowHero = GetComponent<EnemyFollowHero>();
            enemyFollowHero.enabled = false;
        }

        private void Update()
        {
            if (!gameFactory.HeroObject) return;

            if (Vector3.Distance(transform.position, gameFactory.HeroObject.transform.position) < radiusToSpotHero)
            {
                StartFollowHero();
            }
            else
            {
                StopFollowHero();
            }
        }

        private void StartFollowHero()
        {
            if (!enemyFollowHero.enabled)
            {
                enemyFollowHero.enabled = true;
            }
        }

        private void StopFollowHero()
        {
            enemyFollowHero.enabled = false;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.2f, 1.0f, 0.2f, 0.4f);
            Gizmos.DrawSphere(transform.position, radiusToSpotHero);
        }
#endif
    }
}