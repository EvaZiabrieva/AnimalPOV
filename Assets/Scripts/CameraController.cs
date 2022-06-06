using UnityEngine;

namespace AnimalPOV
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private AnimationCurve transformPower;
        [SerializeField] private Vector2 maxRotationAngles = new Vector2 (50, 20);
        private ICameraInputProvider inputProvider = new CameraInputProvider();
        
        private void Update()
        {
            Vector2 input = Vector2.ClampMagnitude(inputProvider.GetCameraInput(), 1f);
            transform.localRotation = Quaternion.Euler(
                TransformInput(-input.y) * maxRotationAngles.y,
                TransformInput(input.x) * maxRotationAngles.x, 0);
        }

        private float TransformInput(float value)
        {
            return Mathf.Sign(value) * transformPower.Evaluate(Mathf.Abs(value)); 
        }
    }
}
