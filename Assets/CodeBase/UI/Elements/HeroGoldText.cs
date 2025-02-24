using Assets.CodeBase.Infrustructure.DependencyInjection;
using CodeBase.Infrastructure.Services.ProgressProviders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class HeroGoldText : MonoBehaviour
    {
        [SerializeField] private Text goldText;

        private IProgressProvider progressProvider;

        [Inject]
        public void Construct(IProgressProvider progressProvider)
        {
            this.progressProvider = progressProvider;

            OnGoldAmountChanged(progressProvider.PlayerProgress.HeroStats.GoldAmount);
        }

        private void Start()
        {
            progressProvider.PlayerProgress.HeroStats.GoldAmountChanged += OnGoldAmountChanged;
        }

        private void OnDestroy()
        {
            progressProvider.PlayerProgress.HeroStats.GoldAmountChanged -= OnGoldAmountChanged;
        }

        private void OnGoldAmountChanged(int goldAmount)
        {
            goldText.text = goldAmount.ToString();
        }
    }
}