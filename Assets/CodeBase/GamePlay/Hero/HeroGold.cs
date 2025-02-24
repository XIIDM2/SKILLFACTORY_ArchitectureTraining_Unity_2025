using Assets.CodeBase.Infrustructure.DependencyInjection;
using CodeBase.DATA;
using CodeBase.Infrastructure.Services.ProgressProviders;
using CodeBase.Infrastructure.Services.ProgressSavers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGold : MonoBehaviour
{
    private IProgressProvider progressProvider;

    [Inject]
    public void Construct(IProgressProvider progressProvider)
    {
        this.progressProvider = progressProvider;
    }
    public void AddGold(int goldAmount)
    {
        if (goldAmount < 0) return;

        progressProvider.PlayerProgress.HeroStats.GoldAmount += goldAmount;
    }

    public void RemoveGold(int goldAmount)
    {
        if (progressProvider.PlayerProgress.HeroStats.GoldAmount < goldAmount || goldAmount < 0) return;

        progressProvider.PlayerProgress.HeroStats.GoldAmount -= goldAmount;
    }

    public int GetGoldAmount()
    {
        return progressProvider.PlayerProgress.HeroStats.GoldAmount;
    }
}
