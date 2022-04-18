using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementParameters
{
    public interface IMovementParameters
    {
        float MovementSpeed { get; }
        float RotationSpeed { get; }
        float JumpForce { get; }
    }
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
