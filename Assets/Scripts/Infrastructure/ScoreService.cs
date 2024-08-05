using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class ScoreService
    {
        public int Score { get; private set; }

        public event Action<int> OnChange;

        public ScoreService(int score)
        {
            Score = score;
        }

        //TODO save/load

        public void AddPoints(int points)
        {
            if (points <= 0)
                return;

            Score += points;
            OnChange?.Invoke(Score);
        }
    }
}