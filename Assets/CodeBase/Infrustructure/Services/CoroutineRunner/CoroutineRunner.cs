using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.CoroutineRunner
{
    public class CoroutineRunner : ICoroutineRunner
    {
        private MonoCoroutineRunner monoCoroutineRunner;

        public CoroutineRunner()
        {
            GameObject coroutineRunnerObject = new GameObject("Coroutine Runner");
            monoCoroutineRunner = coroutineRunnerObject.AddComponent<MonoCoroutineRunner>();

            GameObject.DontDestroyOnLoad(coroutineRunnerObject);
        }

        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return monoCoroutineRunner.StartCoroutine(coroutine);
        }
    }
}