using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalPOV
{
    public interface IMovementParameters
    {
        float MovementSpeed
        {
            get;
        }
        float RotationSpeed
        {
            get;
        }
        float JumpForce
        {
            get;

        }
    }
    [Serializable()] 
    public class Rat : IMovementParameters
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
}
