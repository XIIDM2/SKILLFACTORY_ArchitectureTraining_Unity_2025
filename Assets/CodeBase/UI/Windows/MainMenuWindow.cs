using Assets.CodeBase.Infrustructure.DependencyInjection;
using CodeBase.Infrastructure.Services.GameStates;
using CodeBase.Infrastructure.Services.SceneStates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class MainMenuWindow : WindowBase
    {
        public event UnityAction NextLevelButtonClick;

        [SerializeField] private Button startLevelButton;
        [SerializeField] private Text levelStartButtonText;

        private string startText = "Start Level:";

        private void Start()
        {
            startLevelButton.onClick.AddListener( () => NextLevelButtonClick?.Invoke());
        }

        public void SetLevelIndex(int levelIndex)
        {
            levelStartButtonText.text = $"{startText} {levelIndex + 1}";
        }

        public void HideStartButton()
        {
            startLevelButton.gameObject.SetActive(false);
        }
    }
}