using CodeBase.GamePlay;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class HealthText : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private Text healthText;

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
            healthText.text = health.CurrentHealth.ToString();
        }
    }
}
