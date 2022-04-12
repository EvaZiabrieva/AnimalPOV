using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalPOV
{
    public class NewBehaviourScript : MonoBehaviour
    {
        public interface IControl
        {

        }
       public class Rat : IControl
        {
            private float movementSpeed = 5f;
            public float MovementSpeed
            {
                get
                {
                    return movementSpeed;
                }
            }
            private float rotationSpeed = 90f;
            public float RotationSpeed
            {
                get
                {
                    return rotationSpeed;
                }
            }
            private float jumpForce = 10f;
            public float JumpForce
            {
                get
                {
                    return jumpForce;
                }
            }
        }

    }
}
