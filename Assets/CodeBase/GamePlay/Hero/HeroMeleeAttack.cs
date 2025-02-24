using CodeBase.DATA;
using CodeBase.Infrastructure.Services.ProgressProviders;
using CodeBase.Infrastructure.Services.ProgressSavers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.GamePlay.Hero
{
    public class HeroMeleeAttack : MonoBehaviour, IProgressLoadHandler
    {
        [SerializeField] private HeroMovement heroMovement;
        [SerializeField] private HeroAnimator heroAnimator;
        [SerializeField] private float attackCooldown;
        [SerializeField] private float attackRadius;
        [SerializeField] private float attackDamage;

        [SerializeField] private Health[] targets;

        private float timer;

        public void LoadProgress(PlayerProgress playerProgress)
        {
            attackDamage = playerProgress.HeroStats.HeroDamage;
        }

        private void Update()
        {
            timer += Time.deltaTime;

            if (CanAttack())
            {
                targets = FindTargets();
                if (targets.Length > 0)
                {
                    TryAttack();
                }
            }
        }

        private void AnimationEventOnHit()
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] != null)
                {
                    targets[i].ApplyDamage(attackDamage);
                }
            }
        }

        private bool CanAttack()
        {
            return timer > attackCooldown && heroMovement.DirectionControl == Vector3.zero;
        }

        private void TryAttack()
        {
            timer = 0;
            heroAnimator.PlayAttack();
        }

        private Health[] FindTargets()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, attackRadius);

            List<Health> targets = new();

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].transform.root.TryGetComponent<Health>(out Health target))
                {
                    if (colliders[i].transform == transform) continue;
                    targets.Add(target);
                }
            }

            return targets.ToArray();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.2f, 1.0f, 0.2f, 0.4f);
            Gizmos.DrawSphere(transform.position, attackRadius);
        }
#endif
    }
}