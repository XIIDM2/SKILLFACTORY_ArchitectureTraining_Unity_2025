using CodeBase.DATA;
using CodeBase.GamePlay;
using CodeBase.Infrastructure.Services.ProgressSavers;
using System;
using UnityEngine;

namespace CodeBase.GamePlay.Hero
{
    public class HeroHealth : Health, IHealthRegeneratable, IProgressLoadHandler
    {
        [SerializeField] private float healthRegenAmount;
        [SerializeField] private float healthRegenDelay;

        private float timer;

        public void LoadProgress(PlayerProgress playerProgress)
        {
            maxHealth = playerProgress.HeroStats.HeroMaxHealth;
            currentHealth = playerProgress.HeroStats.HeroMaxHealth;
        }

        void Update()
        {
            timer += Time.deltaTime;

            if (timer >= healthRegenDelay)
            {
                HealthRegeneration(healthRegenAmount);
                timer = 0;
            }
        }

        public void HealthRegeneration(float healthRegenAmount)
        {
            if (currentHealth == maxHealth || healthRegenAmount == 0) return;

            currentHealth += healthRegenAmount;

            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }

            ChangeHealthEvent();
        }
    }
}