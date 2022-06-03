using UnityEngine;

namespace AnimalPOV
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraInputProvider CameraInputProvider;
        public Vector2 maxRotationAngles = new Vector2 (50, 20);
        private ICameraInputProvider inputProvider = new CameraInputProvider();
        void Update()
        {
            transform.localRotation = Quaternion.Euler(
                -inputProvider.GetCameraInput().y * maxRotationAngles.y,
                inputProvider.GetCameraInput().x * maxRotationAngles.x, 0);
        }
    }
}
