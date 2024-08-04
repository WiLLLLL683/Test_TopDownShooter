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
        private readonly BulletFactory bulletFactory;

        public PlayerFactory(Player prefab, Transform spawnPoint, IInput input, BulletFactory bulletFactory)
        {
            this.prefab = prefab;
            this.spawnPoint = spawnPoint;
            this.input = input;
            this.bulletFactory = bulletFactory;
        }

        public Player Create()
        {
            Player player = GameObject.Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            player.Init(input, bulletFactory);
            return player;
        }
    }
}