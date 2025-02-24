using CodeBase.DATA;
using CodeBase.Infrastructure.Services.ProgressSavers;
using UnityEngine;

namespace CodeBase.GamePlay.Hero
{
    public class HeroMovement : MonoBehaviour, IProgressLoadHandler
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Transform viewTransform;

        [SerializeField] private float movementSpeed;

        private Vector3 directionControl;
        public Vector3 DirectionControl => directionControl;

        public void LoadProgress(PlayerProgress playerProgress)
        {
            movementSpeed = playerProgress.HeroStats.HeroMovementSpeed;
        }

        private void Update()
        {
            if (directionControl.magnitude > 0)
            {
                characterController.Move(Time.deltaTime * movementSpeed * directionControl);
                viewTransform.rotation = Quaternion.LookRotation(directionControl);
            }
            else
            {
                characterController.Move(Vector3.zero);
            }
        }

        public void SetMovementDirection(Vector2 movementDirection)
        {
            directionControl.x = movementDirection.x;
            directionControl.z = movementDirection.y;
            directionControl.Normalize();
        }

    }
}
