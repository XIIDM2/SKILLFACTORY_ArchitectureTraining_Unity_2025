using Assets.CodeBase.Configs.Scene;
using CodeBase.UI.Elements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.GamePlay.UI.Services
{
    public class WindowProvider : IWindowProvider
    {
        private IUIFactory UIfactory;
        private IConfigProvider configProvider;

        public WindowProvider(IUIFactory uIfactory, IConfigProvider configProvider)
        {
            UIfactory = uIfactory;
            this.configProvider = configProvider;
        }

        public void Open(WindowID windowID)
        {
            if (UIfactory.UIRoot == null)
            {
                UIfactory.CreateUIRoot();
            }

            WindowConfig windowConfig = configProvider.GetWindowConfig(windowID);

            if (windowID == WindowID.VictoryWindow || windowID == WindowID.DefeatWindow)
            {
                UIfactory.CreateLevelResultPresenter(windowConfig);
            }
            else if (windowID == WindowID.MainMenuWindow)
            {
                UIfactory.CreateMainMenuPresenter(windowConfig);
            }
        }
    }
}