using CodeBase.DATA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ProgressProviders
{
    public class ProgressProvider : IProgressProvider
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}