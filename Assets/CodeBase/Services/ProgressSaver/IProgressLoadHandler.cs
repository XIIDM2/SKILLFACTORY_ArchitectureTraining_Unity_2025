using CodeBase.DATA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ProgressSavers
{
    public interface IProgressLoadHandler
    {
        void LoadProgress(PlayerProgress playerProgress);
    }
}