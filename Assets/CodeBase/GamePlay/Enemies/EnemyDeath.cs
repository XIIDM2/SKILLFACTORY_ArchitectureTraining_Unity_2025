using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.GamePlay.Enemies
{
    public class EnemyDeath : MonoBehaviour
    {
        private EnemyHealth health;
        void Start()
        {
            health = GetComponent<EnemyHealth>();

            health.Death += OnDeathEvent;
        }

        private void OnDestroy()
        {
            health.Death -= OnDeathEvent;
        }

        private void OnDeathEvent()
        {
            Destroy(gameObject);
        }
    }
}