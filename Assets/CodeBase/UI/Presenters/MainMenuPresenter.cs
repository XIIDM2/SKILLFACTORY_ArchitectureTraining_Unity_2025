using CodeBase.Infrastructure.Services.GameStates;
using CodeBase.Infrastructure.Services.ProgressProviders;
using CodeBase.UI.Elements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPresenter : PresenterWindowBase<MainMenuWindow>
{
    private IConfigProvider configProvider;
    private IProgressProvider progressProvider;
    private IGameStateSwitcher gameStateSwitcher;

    [SerializeField] private MainMenuWindow window;

    public MainMenuPresenter(IConfigProvider configProvider, IProgressProvider progressProvider, IGameStateSwitcher gameStateSwitcher)
    {
        this.configProvider = configProvider;
        this.progressProvider = progressProvider;
        this.gameStateSwitcher = gameStateSwitcher;
    }

    public override void SetWindow(MainMenuWindow window)
    {
        this.window = window;

        int currentLevelIndex = progressProvider.PlayerProgress.LevelIndex;

        if (currentLevelIndex >= configProvider.ScenesAmount)
        {
            window.HideStartButton();
        }
        else
        {
            window.SetLevelIndex(currentLevelIndex);
        }

        window.NextLevelButtonClick += OnNextLevelButtonClick;
        window.CleanUp += OnCleanUp;

    }

    private void OnCleanUp()
    {
        window.NextLevelButtonClick -= OnNextLevelButtonClick;
        window.CleanUp -= OnCleanUp;
    }

    private void OnNextLevelButtonClick()
    {
        gameStateSwitcher.EnterState<LoadNextSceneState>();
    }
}
