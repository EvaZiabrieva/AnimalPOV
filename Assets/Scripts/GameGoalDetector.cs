using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace AnimalPOV
{
    public class GameGoalDetector : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerLabel;
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject finishScreen;
        [SerializeField] private FoodTrigger foodTrigger;
        private bool isGameFinished;
        private float timer;
        private void Update()
        {
            if (isGameFinished)
                return;

            timer += Time.deltaTime;
            int currentTime = (int)timer;
            int seconds = currentTime % 60;
            int minutes = currentTime / 60;

            
            timerLabel.text = minutes + ":" + (seconds < 10 ? "0" : "") + seconds;

            slider.value = foodTrigger.Saturation; 
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Home>() != null)
            {
                isGameFinished = foodTrigger.Saturation >= 1;
                finishScreen.SetActive(isGameFinished);
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
