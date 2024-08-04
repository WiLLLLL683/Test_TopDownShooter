using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class PlayerFactory
    {
        private Player prefab;
        private Transform spawnPoint;
        private readonly IInput input;

        public PlayerFactory(Player prefab, Transform spawnPoint, IInput input)
        {
            this.prefab = prefab;
            this.spawnPoint = spawnPoint;
            this.input = input;
        }

        public Player Create()
        {
            Player player = GameObject.Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            player.Init(input);
            return player;
        }
    }
}