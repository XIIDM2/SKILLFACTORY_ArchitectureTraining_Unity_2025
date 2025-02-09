using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using System;

namespace CodeBase.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(string sceneName, Action onloaded = null);
    }
}