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
    public class LevelResultWindow : WindowBase
    {
        public event UnityAction MainMenuButtonClick;

        [SerializeField] private Button mainMenuButton;

        private void Start()
        {
            mainMenuButton.onClick.AddListener(() => MainMenuButtonClick?.Invoke());
        }

    }
}