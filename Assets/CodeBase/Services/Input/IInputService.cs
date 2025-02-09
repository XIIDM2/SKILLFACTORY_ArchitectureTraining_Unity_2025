using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public interface IInputService : IService
    {
        bool IsEnabled { get; set; }
        Vector2 MovementAxis { get; }
    }
}