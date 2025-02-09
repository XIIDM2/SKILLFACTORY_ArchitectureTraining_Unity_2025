using CodeBase.Infrastructure.Services.CoroutineRunner;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            this.coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onloaded = null)
        {
            coroutineRunner.StartCoroutine(LoadAsync(sceneName, onloaded));
        }

        private IEnumerator LoadAsync(string sceneName, Action onloaded = null)
        {
            
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                yield return null;
                onloaded?.Invoke();
                yield break;
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone)
            {
                yield return null;
            }

            onloaded?.Invoke();
        }
    }
}