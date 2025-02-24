using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.DATA
{
    [System.Serializable]
    public class HeroStats
    {
        public float HeroMaxHealth;
        public float HeroDamage;
        public float HeroMovementSpeed;
        public int GoldAmount
        { get
            {
                return goldAmount;
            }
            set
            {
                goldAmount = value;
                GoldAmountChanged?.Invoke(goldAmount);
                Debug.Log($"Количество золота: {goldAmount}");
            }
        }

        public event UnityAction<int> GoldAmountChanged;

        [SerializeField] private int goldAmount;

        public void SaveHeroGold(int goldAmount)
        {
            this.goldAmount = goldAmount;
        }

        public static HeroStats GetDefaultHeroStats()
        {
            HeroStats heroStats = new()
            {
                HeroMaxHealth = 100,
                HeroDamage = 100,
                HeroMovementSpeed = 5,
                GoldAmount = 10,
            };

            return heroStats;
        }
    }
}