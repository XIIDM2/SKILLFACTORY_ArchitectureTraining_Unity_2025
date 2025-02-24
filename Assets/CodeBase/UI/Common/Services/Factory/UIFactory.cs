using Assets.CodeBase.Configs.Scene;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.UI.Elements;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.GamePlay.UI.Services
{
    public class UIFactory : IUIFactory
    {
        private const string UI_ROOT_GAMEOBJECT_NAME = "UI Root";

        private DependencyInjectionContainer DIcontainer;

        public Transform UIRoot { get; set; }

        public UIFactory(DependencyInjectionContainer dIcontainer)
        {
            DIcontainer = dIcontainer;
        }

        public LevelResultPresenter CreateLevelResultPresenter(WindowConfig windowConfig)
        {
            return CreateWindow<LevelResultWindow, LevelResultPresenter>(windowConfig);
        }

        public MainMenuPresenter CreateMainMenuPresenter(WindowConfig windowConfig)
        {
            return CreateWindow<MainMenuWindow, MainMenuPresenter>(windowConfig); ;
        }

        public void CreateUIRoot()
        {
            UIRoot = new GameObject(UI_ROOT_GAMEOBJECT_NAME).transform;
        }

        private TPresenter CreateWindow<TWindow, TPresenter>(WindowConfig windowConfig) where TWindow : WindowBase where TPresenter : PresenterWindowBase<TWindow>
        {
            TWindow window = DIcontainer.Instantiate(windowConfig.windowPrefab).GetComponent<TWindow>();

            window.transform.SetParent(UIRoot);
            window.SetTitleText(windowConfig.windowTitle);

            TPresenter levelResultPresenter = DIcontainer.InstantiateAndInject<TPresenter>();

            levelResultPresenter.SetWindow(window);

            return levelResultPresenter;

        }
    }
}