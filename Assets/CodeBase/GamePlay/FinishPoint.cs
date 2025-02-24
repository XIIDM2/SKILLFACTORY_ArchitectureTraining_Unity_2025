using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.GamePlay
{
    public class FinishPoint : MonoBehaviour
    {
        public static float Radius = 3.0f;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, Radius);
        }
#endif
    }
}