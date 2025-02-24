using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.GamePlay
{
    public class Health : MonoBehaviour
    {
        [SerializeField] protected float maxHealth;
        [SerializeField] protected float currentHealth;

        public UnityAction HealthChanged;
        public UnityAction Death;

        public float MaxHealth => maxHealth;
        public float CurrentHealth => currentHealth;

        public void ApplyDamage(float damage)
        {
            if (currentHealth == 0 || damage == 0) return;

            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Death?.Invoke();
            }

            ChangeHealthEvent();
        }

        protected void ChangeHealthEvent()
        {
            HealthChanged?.Invoke();
        }
    }
}