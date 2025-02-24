using CodeBase.Configs;
using CodeBase.GamePlay;
using UnityEngine;

namespace CodeBase.GamePlay.Enemies
{
    public class EnemyHealth : Health, IEnemyConfigInstaller
    {
        public void InstallConfig(EnemyConfig enemyConfig)
        {
            maxHealth = enemyConfig.MaxHealth;
            currentHealth = enemyConfig.MaxHealth;
        }
    }
}