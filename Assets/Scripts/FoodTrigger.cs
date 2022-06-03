using UnityEngine;

namespace AnimalPOV
{
    public class FoodTrigger : MonoBehaviour, IEffectsModificator
    {
        public float SpeedModificator { get; private set; } = 1f;
        public float JumpModificator { get; private set; } = 1f;
        public float Saturation { get; private set; } = 0f;

        private float timer;
        private FoodEffects foodEffects;

        private void OnTriggerEnter(Collider other)
        {
            foodEffects = other.GetComponent<FoodEffects>();
        }
        private void OnTriggerExit(Collider other)
        {
            foodEffects = null;
        }

        private void Update()
        {
            timer -= Time.deltaTime;

            // TODO: move input handling to interface
            if (foodEffects != null && Input.GetKeyDown(KeyCode.E))
            {
      
                SpeedModificator = foodEffects.SpeedModificator;
                JumpModificator = foodEffects.JumpModificator;
                timer = foodEffects.Duration;
                Saturation = Mathf.Clamp01(Saturation + foodEffects.Saturation);

                Destroy(foodEffects.gameObject);
                foodEffects = null;
            }

            if (timer <= 0)
            {
                SpeedModificator = 1f;
                JumpModificator = 1f;
            }
        }
    }
}
