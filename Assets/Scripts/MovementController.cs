using UnityEngine;

namespace AnimalPOV
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private MovementParameters movementParameters;
        [SerializeField] private LayerMask raycastMask;
        private float horizontalRotation;
        private IInputProvider inputProvider = new InputProvider();
        public Rigidbody rb;

        private void Update()
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position + Vector3.up * 0.05f, Vector3.down);
            Quaternion targetRotation;
            if (Physics.Raycast(ray, out hit, 0.1f, raycastMask))
                targetRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            else
                targetRotation = Quaternion.identity;
            

            float angle = Vector3.Angle(Vector3.up, hit.normal);
            float speedModificator = Mathf.InverseLerp(movementParameters.MaxAngle, 0, angle);
            float horizontalMovement = inputProvider.GetForwardMovement() * movementParameters.MovementSpeed * speedModificator * Time.deltaTime;

            horizontalRotation += inputProvider.GetRotation() * movementParameters.RotationSpeed * Time.deltaTime;
            targetRotation *= Quaternion.Euler(0, horizontalRotation, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            transform.position += targetRotation * new Vector3(horizontalMovement, 0f, 0f);


            if(inputProvider.IsTryJump())
                rb.AddForce(new Vector3(0, movementParameters.JumpForce, 0), ForceMode.Impulse);
        }
    }
}
