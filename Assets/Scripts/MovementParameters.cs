using System;
using UnityEngine;

namespace AnimalPOV
{
    [Serializable]
    public class MovementParameters : IMovementParameters
    {
        [SerializeField]
        private float movementSpeed = 5f;
        public float MovementSpeed => movementSpeed;
        [SerializeField]
        private float rotationSpeed = 90f;
        public float RotationSpeed => rotationSpeed;
        [SerializeField]
        private float jumpForce = 10f;
        public float JumpForce => jumpForce;
    }
}
