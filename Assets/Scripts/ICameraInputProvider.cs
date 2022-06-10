using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalPOV
{
    public interface ICameraInputProvider
    {
        Vector2 GetCameraInput();
    }
}
