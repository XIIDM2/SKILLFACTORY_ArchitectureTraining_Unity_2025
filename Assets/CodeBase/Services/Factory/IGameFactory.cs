using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(Vector3 position, Quaternion rotation);
        VirtualJoyStick CreateVirtualJoyStick();
        FollowCamera CreateFollowCamera();

        GameObject Hero {  get; }
        VirtualJoyStick VirtualJoyStick {  get; }
        FollowCamera FollowCamera {  get; }

    }
}