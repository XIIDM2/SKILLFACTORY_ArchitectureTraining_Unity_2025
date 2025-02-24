using UnityEngine;

namespace CodeBase.GamePlay.Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private const string isMoving = "IsMoving";
        private const string attackTrigger = "Attack";
        private const float movementThreshold = 0.05f;

        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;

        private void Update()
        {
            animator.SetBool(isMoving, characterController.velocity.magnitude >= movementThreshold);
        }

        public void PlayAttack()
        {
            animator.SetTrigger(attackTrigger);
        }
    }
}

