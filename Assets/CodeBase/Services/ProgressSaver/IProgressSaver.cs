using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ProgressSavers
{
    public interface IProgressSaver : IService
    {
        void AddObjects(GameObject gameObject);
        void LoadProgress();
        void RemoveObjects();
        void SaveProgress();
    }
}