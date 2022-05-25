using UnityEngine;

namespace AnimalPOV
{
    public class FoodTrigger : MonoBehaviour, IEffectsModificator
    {
        public float SpeedModificator { get; private set; } = 1f;
        public float JumpModificator { get; private set; } = 1f;
        public float Saturation { get; private set; } = 0f;

        private float timer;
        private Collider foodCollider;

        private void OnTriggerEnter(Collider other)
        {
            foodCollider = other;
        }
        private void OnTriggerExit(Collider other)
        {
            foodCollider = null;
        }

        private void Update()
        {
            timer -= Time.deltaTime;

            // TODO: move input handling to interface
            if (foodCollider != null && Input.GetKeyDown(KeyCode.E))
            {
                FoodEffects foodEffects = foodCollider.GetComponent<FoodEffects>();

                SpeedModificator = foodEffects.SpeedModificator;
                JumpModificator = foodEffects.JumpModificator;
                timer = foodEffects.Duration;
                Saturation = Mathf.Clamp01(Saturation + foodEffects.Saturation);

                Destroy(foodCollider.gameObject);
                foodCollider = null;
            }

            if (timer <= 0)
            {
                SpeedModificator = 1f;
                JumpModificator = 1f;
            }
        }
    }
}
