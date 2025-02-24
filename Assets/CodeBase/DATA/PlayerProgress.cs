using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.DATA
{
    [System.Serializable]
    public class PlayerProgress
    {
        public int LevelIndex;
        public HeroStats HeroStats;

        public static PlayerProgress GetDefaultPlayerProgress()
        {
            PlayerProgress playerProgress = new()
            {
                LevelIndex = 0,
                HeroStats = HeroStats.GetDefaultHeroStats()
            };

            return playerProgress;
        }
    }
}