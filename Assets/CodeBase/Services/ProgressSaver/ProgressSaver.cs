using Assets.CodeBase.Services.ProgressSaver;
using CodeBase.DATA;
using CodeBase.Infrastructure.Services.ProgressProviders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ProgressSavers
{
    public class ProgressSaver : IProgressSaver
    {
        private const string PROGRESS_KEY = "Progress";

        private IProgressProvider progressProvider;
        private List<IProgressBeforeSaveHandler> progressBeforeSaveHandlers;
        private List<IProgressLoadHandler> progressLoadHandlers;

        public ProgressSaver(IProgressProvider progressProvider)
        {
            this.progressProvider = progressProvider;
            progressBeforeSaveHandlers = new();
            progressLoadHandlers = new();
        }

        public void AddObjects(GameObject gameObject)
        {
            foreach (IProgressLoadHandler progressLoadHandler in gameObject.GetComponentsInChildren<IProgressLoadHandler>())
            {
                if (!progressLoadHandlers.Contains(progressLoadHandler))
                {
                    progressLoadHandlers.Add(progressLoadHandler);
                }
            }

            foreach (IProgressBeforeSaveHandler progressBeforeSaveHandler in gameObject.GetComponentsInChildren<IProgressBeforeSaveHandler>())
            {
                if (!progressBeforeSaveHandlers.Contains(progressBeforeSaveHandler))
                {
                    progressBeforeSaveHandlers.Add(progressBeforeSaveHandler);
                }
            }
        }

        public void RemoveObjects()
        {
            progressBeforeSaveHandlers.Clear();
            progressLoadHandlers.Clear();
        }

        public void LoadProgress()
        {
            if (!PlayerPrefs.HasKey(PROGRESS_KEY))
            {
                progressProvider.PlayerProgress = PlayerProgress.GetDefaultPlayerProgress();
            }
            else
            {
                progressProvider.PlayerProgress = JsonUtility.FromJson<PlayerProgress>(PlayerPrefs.GetString(PROGRESS_KEY));
            }

            foreach (IProgressLoadHandler progressLoadHandler in progressLoadHandlers)
            {
                progressLoadHandler.LoadProgress(progressProvider.PlayerProgress);
            }
        }

        public void SaveProgress()
        {
            foreach (IProgressBeforeSaveHandler progressBeforeSaveHandler in progressBeforeSaveHandlers)
            {
                progressBeforeSaveHandler.UpdatePlayerProgressBeforeSave(progressProvider.PlayerProgress);
            }

            PlayerPrefs.SetString(PROGRESS_KEY, JsonUtility.ToJson(progressProvider.PlayerProgress));
            Debug.Log($"Saved to PlayerPrefs under key '{PROGRESS_KEY}': {PlayerPrefs.GetString(PROGRESS_KEY)}");
        }
    }
}