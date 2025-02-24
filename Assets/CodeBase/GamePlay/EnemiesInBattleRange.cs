using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.GamePlay;
using CodeBase.Infrastructure.Services.Factory;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInBattleRange : MonoBehaviour, IService
{
    [SerializeField] private float radiusToBeInBattle;
    [SerializeField] private float timeToCheckEnemiesInRange;
    [SerializeField] private List<Health> enemiesInRange;
    [SerializeField] private bool heroInBattle;

    public bool HeroInBattle => heroInBattle;
    
    private IGameFactory gameFactory;

    private float timer;

    [Inject]
    public void Construct(IGameFactory gameFactory)
    {
        this.gameFactory = gameFactory;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeToCheckEnemiesInRange || enemiesInRange.Count == 0)
        {
            ClearEnemiesCountInRange();
            CheckEnemiesInRange();

            heroInBattle = enemiesInRange.Count > 0;

            timer = 0;
        }
            
    }

    private void CheckEnemiesInRange()
    {
        if (!gameFactory.HeroObject) return;

        Collider[] colliders = Physics.OverlapSphere(gameFactory.HeroObject.transform.position, radiusToBeInBattle);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].transform == gameFactory.HeroObject.transform) continue;

            if (colliders[i].transform.root.TryGetComponent<Health>(out Health enemy))
            {
                enemiesInRange.Add(enemy);
            }
        }
    }

    private void ClearEnemiesCountInRange()
    {
        enemiesInRange.Clear();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            if (gameFactory.HeroObject)
            {
                Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
                Gizmos.DrawSphere(gameFactory.HeroObject.transform.position, radiusToBeInBattle);
            }
        }
    }
#endif
}
