using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.UI.Elements;

namespace CodeBase.GamePlay.UI.Services
{
    public interface IWindowProvider : IService
    {
        void Open(WindowID windowID);
    }
}