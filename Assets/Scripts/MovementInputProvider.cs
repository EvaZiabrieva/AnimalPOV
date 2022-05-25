using UnityEngine;

namespace AnimalPOV
{
    public class MovementInputProvider : IMovementInputProvider
    {
        public float GetForwardMovement()
        {
            return Input.GetAxis("Vertical");
        }
        public bool IsTryJump()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
        public float GetRotation()
        {
            return Input.GetAxis("Horizontal");
        }
    }
}
