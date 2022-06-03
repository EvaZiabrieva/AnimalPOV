using System;
using UnityEngine;

namespace AnimalPOV
{
    [Serializable]
    public class MovementParameters : IMovementParameters
    {
        [SerializeField]
        private float movementSpeed = 10f;
        public float MovementSpeed => movementSpeed * effectsModificator.SpeedModificator;
        [SerializeField]
        private float rotationSpeed = 90f;
        public float RotationSpeed => rotationSpeed;
        [SerializeField]
        private float jumpForce = 10f;
        public float JumpForce => jumpForce * effectsModificator.JumpModificator;
        [SerializeField]
        private float maxAngle = 80f;
        public float MaxAngle => maxAngle;

        private IEffectsModificator effectsModificator;
        public void SetModificator(IEffectsModificator effectsModificator)
        {
            this.effectsModificator = effectsModificator;
        }

    }
}
