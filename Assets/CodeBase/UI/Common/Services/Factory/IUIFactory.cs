using Assets.CodeBase.Configs.Scene;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using UnityEngine;

namespace CodeBase.GamePlay.UI.Services
{
    public interface IUIFactory : IService
    {
        Transform UIRoot { get; set; }

        LevelResultPresenter CreateLevelResultPresenter(WindowConfig windowConfig);
        MainMenuPresenter CreateMainMenuPresenter(WindowConfig windowConfig);
        void CreateUIRoot();
    }
}