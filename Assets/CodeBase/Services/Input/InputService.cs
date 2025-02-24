using CodeBase.UI.Elements;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class InputService : IInputService
    {
        private const string AxisNameHorizontal = "Horizontal";
        private const string AxisNameVertical = "Vertical";

        private bool enabled = true;
        private Vector2 GetMovementAxis()
        {
            if (!enabled) return Vector2.zero;

            if (VirtualJoyStick.Value != Vector2.zero)
            {
                return VirtualJoyStick.Value;
            }
            else
            {
                return new Vector2(Input.GetAxis(AxisNameHorizontal), Input.GetAxis(AxisNameVertical));
            }
        }

        public Vector2 MovementAxis
        {
            get { return GetMovementAxis(); }
        }

        public bool IsEnabled { get => enabled; set => enabled = value; }
    }
}

