using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Input input;

        private void Awake()
        {
            input.Enable();
            player.Init(input);
        }
    }
}