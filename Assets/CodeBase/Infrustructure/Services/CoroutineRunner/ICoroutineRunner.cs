﻿using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.CoroutineRunner
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}