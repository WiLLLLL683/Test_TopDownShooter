using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownShooter
{
    public class HudUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Button exitButton;

        private ScoreService scoreService;

        public void Init(ScoreService scoreService)
        {
            this.scoreService = scoreService;

            UpdateScoteText(scoreService.Score);

            scoreService.OnChange += UpdateScoteText;
            exitButton.onClick.AddListener(ExitToMainMenu);
        }

        private void OnDestroy()
        {
            scoreService.OnChange -= UpdateScoteText;
            exitButton.onClick.RemoveListener(ExitToMainMenu);
        }

        private void UpdateScoteText(int score) => scoreText.text = $"Score: {score}";
        private void ExitToMainMenu() => Debug.Log("Exit"); //TODO
    }
}