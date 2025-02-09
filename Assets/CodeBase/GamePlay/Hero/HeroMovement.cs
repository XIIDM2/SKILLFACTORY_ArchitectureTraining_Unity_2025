using UnityEngine;

namespace CodeBase.GamePlay.Hero
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Transform viewTransform;

        [SerializeField] private float movementSpeed;

        private Vector3 directionControl;

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
