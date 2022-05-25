using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalPOV
{
    public class FoodTrigger : MonoBehaviour, IEffectsModificator
    {
        private Collider foodCollider;

        public float SpeedModificator { get; private set; } = 1f;

        public float JumpModificator { get; private set; } = 1f;
        private float timer;

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

            if (foodCollider != null && Input.GetKeyDown(KeyCode.E))
            {
                FoodEffects foodEffects = foodCollider.GetComponent<FoodEffects>();

                SpeedModificator = foodEffects.SpeedModificator;
                JumpModificator = foodEffects.JumpModificator;
                timer = foodEffects.Duration;

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
