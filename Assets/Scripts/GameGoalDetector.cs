using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace AnimalPOV
{
    public class GameGoalDetector : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerLabel;
        [SerializeField] private Slider slider;
        [SerializeField] private FoodTrigger foodTrigger;
        private float timer;
        private void Update()
        {
            timer += Time.deltaTime;
            int currentTime = (int)timer;
            int seconds = currentTime % 60;
            int minutes = currentTime / 60;

            timerLabel.text = minutes + ":" + (seconds < 10 ? "0" : "") + seconds;

            slider.value = foodTrigger.Saturation;
        }
    }
}
