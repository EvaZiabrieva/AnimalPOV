using System;
using UnityEngine;

namespace AnimalPOV
{
    public class MovementController : MonoBehaviour, IMovementEvents 
    {
        [SerializeField] private MovementParameters movementParameters;
        [SerializeField] private LayerMask raycastMask;
        [SerializeField] private new Rigidbody rigidbody;
        private float horizontalRotation;
        private MovementState movementState;
        private IInputProvider inputProvider = new InputProvider();

        public event Action Idle;
        public event Action Run;
        public event Action Jump;

        private void Update()
        {
            bool isGrounded = true;
            RaycastHit hit;
            Ray ray = new Ray(transform.position + Vector3.up * 0.05f, Vector3.down);
            Quaternion targetRotation;
            if (Physics.Raycast(ray, out hit, 0.1f, raycastMask))
                targetRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            else
            {
                targetRotation = Quaternion.identity;
                isGrounded = false;
            }
            

            float angle = Vector3.Angle(Vector3.up, hit.normal);
            float speedModificator = Mathf.InverseLerp(movementParameters.MaxAngle, 0, angle);
            float horizontalMovement = inputProvider.GetForwardMovement() * movementParameters.MovementSpeed * speedModificator * Time.deltaTime;
            if (isGrounded)
            {
                if (horizontalMovement == 0f)
                {
                    if (movementState != MovementState.Idle)
                    {
                        Idle?.Invoke();
                        movementState = MovementState.Idle;
                    }
                }
                else
                {
                    if (movementState != MovementState.Run)
                    {
                        Run?.Invoke();
                        movementState = MovementState.Run;
                    }
                }
            }

            horizontalRotation += inputProvider.GetRotation() * movementParameters.RotationSpeed * Time.deltaTime;
            targetRotation *= Quaternion.Euler(0, horizontalRotation, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            transform.position += targetRotation * new Vector3(horizontalMovement, 0f, 0f);


            if (inputProvider.IsTryJump() && isGrounded)
            {
                rigidbody.AddForce(new Vector3(0, movementParameters.JumpForce, 0), ForceMode.Impulse);
                Jump?.Invoke();
                movementState = MovementState.Jump;
            }
        }

        private enum MovementState
        {
            Idle,
            Run,
            Jump
        }
    }
}
