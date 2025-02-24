using CodeBase.GamePlay.Hero;
using UnityEngine;
using UnityEngine.AI;
using CodeBase.GamePlay.Enemies;
using CodeBase.Infrastructure.Services.Factory;
using Assets.CodeBase.Infrustructure.DependencyInjection;
using CodeBase.Configs;


public class EnemyMeleeAttack : MonoBehaviour, IEnemyConfigInstaller
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private EnemyAnimator enemyAnimator;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDamage;

    private IGameFactory gameFactory;

    private HeroHealth heroHealth;

    private float timer;

    [Inject]
    public void Construct(IGameFactory gameFactory)
    {
        this.gameFactory = gameFactory;
    }

    public void InstallConfig(EnemyConfig enemyConfig)
    {
        attackCooldown = enemyConfig.AttackCooldown;
        attackRadius = enemyConfig.AttackRadius;
        attackDamage = enemyConfig.AttackDamage;
    }

    private void Start()
    {
        heroHealth = gameFactory.HeroHealth;
    }
    private void Update()
    {
        if (heroHealth == null) return;

        timer += Time.deltaTime;

        if (CanAttack())
        {

                TryAttack();
            
        }
    }

    private void AnimationEventOnHit()
    {
        if (heroHealth != null)
        {
            heroHealth.ApplyDamage(attackDamage);
        }
    }

    private bool CanAttack()
    {
        return timer > attackCooldown && navMeshAgent.velocity.magnitude < 0.1f && Vector3.Distance(transform.position, gameFactory.HeroHealth.transform.position) < attackRadius;
    }

    private void TryAttack()
    {
        timer = 0;
        enemyAnimator.PlayAttack();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.2f, 1.0f, 0.2f, 0.4f);
        Gizmos.DrawSphere(transform.position, attackRadius);
    }
#endif
}
