using UnityEngine;

namespace AnimalPOV
{
    public class CameraInputProvider : ICameraInputProvider
    {
        public Vector2 GetCameraInput()
        {
            float max = 1f;
            float min = -1f;
            return new Vector2(
                Mathf.Lerp(min, max, Input.mousePosition.x/ Screen.width),
                Mathf.Lerp(min, max, Input.mousePosition.y/ Screen.height));
        }
    }
}
