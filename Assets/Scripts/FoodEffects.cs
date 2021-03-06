using UnityEngine;

namespace AnimalPOV
{
    public class FoodEffects : MonoBehaviour
    {
        [SerializeField] private float speedModificator = 1f;
        [SerializeField] private float jumpModificator = 1f;
        [SerializeField] private float duration = 3f;
        [SerializeField] private float saturation = 0.3f;
        public float SpeedModificator => speedModificator;
        public float JumpModificator => jumpModificator;
        public float Duration => duration;
        public float Saturation => saturation;
    }
}
