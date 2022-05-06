using UnityEngine;

namespace AnimalPOV
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private MovementParameters movementParameters;
        private float horizontalRotation;
        private IInputProvider inputProvider = new InputProvider();

        private void Update()
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position + Vector3.up * 0.05f, Vector3.down);
            if (Physics.Raycast(ray, out hit, 0.1f))
                transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            else
                transform.rotation = Quaternion.identity;

            float angle = Vector3.Angle(Vector3.up, hit.normal);
            float speedModificator = Mathf.InverseLerp(movementParameters.MaxAngle, 0, angle);
            float horizontalMovement = inputProvider.GetForwardMovement() * movementParameters.MovementSpeed * speedModificator * Time.deltaTime;

            horizontalRotation += inputProvider.GetRotation() * movementParameters.RotationSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(0, horizontalRotation, 0);
            transform.position += transform.rotation * new Vector3(horizontalMovement, 0f, 0f);
        }
    }
}
