using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.GamePlay.Enemies;
using CodeBase.GamePlay.Hero;
using CodeBase.UI.Elements;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        Task<GameObject> CreateHeroAsync(Vector3 position, Quaternion rotation);
        Task<GameObject> CreateEnemy(EnemyID enemyID, Vector3 position);
        Task<VirtualJoyStick> CreateVirtualJoyStick();
        Task<FollowCamera> CreateFollowCamera();

        GameObject HeroObject {  get; }
        HeroHealth HeroHealth {  get; }
        HeroGold HeroGold { get; }
        VirtualJoyStick VirtualJoyStick {  get; }
        FollowCamera FollowCamera {  get; }

    }
}