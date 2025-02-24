using CodeBase.DATA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Services.ProgressSaver
{
    public interface IProgressBeforeSaveHandler
    {
        void UpdatePlayerProgressBeforeSave(PlayerProgress playerProgress);
    }
}