using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalPOV
{
    public class CameraInputProvider : MonoBehaviour, ICameraInputProvider
    {
        public Vector2 GetCameraInput()
        {
            return Input.mousePosition;
        }

        private void Update()
        {
            Debug.Log(GetCameraInput());
        }
    }
}
