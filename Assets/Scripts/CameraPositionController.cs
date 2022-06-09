using UnityEngine;

namespace AnimalPOV
{
    public class CameraPositionController : MonoBehaviour
    {
        public Transform cameraTarget;
        public float positionLerp = 0.2f;
        public float rotationLerp = 0.2f;
        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, cameraTarget.position, positionLerp);
            transform.rotation = Quaternion.Lerp(transform.rotation, cameraTarget.rotation, rotationLerp);
        }
    }
}
