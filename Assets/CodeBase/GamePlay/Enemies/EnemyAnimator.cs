using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.GamePlay.Enemies
{
    public class EnemyAnimator : MonoBehaviour
    {
        private const string isMoving = "IsMoving";
        private const string attackTrigger = "Attack";
        private const float movementThreshold = 0.05f;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void PlayAttack()
        {
            animator.SetTrigger(attackTrigger);
        }

        public void SetMove(bool move)
        {
            animator.SetBool(isMoving, move);
        }
    }
}
