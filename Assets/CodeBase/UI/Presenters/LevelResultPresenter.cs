using CodeBase.Infrastructure.Services.GameStates;
using CodeBase.UI.Elements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelResultPresenter : PresenterWindowBase<LevelResultWindow>
{
    private IGameStateSwitcher gameStateSwitcher;
    private LevelResultWindow window;

    public LevelResultPresenter(IGameStateSwitcher gameStateSwitcher)
    {
        this.gameStateSwitcher = gameStateSwitcher;
    }

    public override void SetWindow(LevelResultWindow window)
    {
        this.window = window;
        window.MainMenuButtonClick += OnMainMenuButtonClick;
        window.CleanUp += OnCleanUp;
    }

    private void OnCleanUp()
    {
        window.MainMenuButtonClick -= OnMainMenuButtonClick;
        window.CleanUp -= OnCleanUp;
    }

    private void OnMainMenuButtonClick()
    {
        gameStateSwitcher.EnterState<LoadMainMenuState>();
    }
}
