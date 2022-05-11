using UnityEngine;

namespace AnimalPOV
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private IMovementEvents movementEvents;
        private void Start()
        {
            movementEvents = GetComponent<IMovementEvents>();
            movementEvents.Idle += MovementEvents_Idle;
            movementEvents.Run += MovementEvents_Run;
            movementEvents.Jump += MovementEvents_Jump;
        }

        private void OnDestroy()
        {
            movementEvents.Idle -= MovementEvents_Idle;
            movementEvents.Run -= MovementEvents_Run;
            movementEvents.Jump -= MovementEvents_Jump;
        }

        private void MovementEvents_Jump()
        {
            animator.SetTrigger("jump");
        }

        private void MovementEvents_Run()
        {
            animator.SetTrigger("run");
        }

        private void MovementEvents_Idle()
        {
            animator.SetTrigger("idle");
        }
    }
}
