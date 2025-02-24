using CodeBase.GamePlay;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private Image healthBar;

        private void Start()
        {
            health.HealthChanged += OnHealthChanged;
            OnHealthChanged();
        }

        private void OnDestroy()
        {
            health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            healthBar.fillAmount = health.CurrentHealth / health.MaxHealth;
        }
    }
}