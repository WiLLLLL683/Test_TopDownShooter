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
        private readonly WeaponFactory weaponFactory;

        public PlayerFactory(Player prefab, Transform spawnPoint, IInput input, WeaponFactory weaponFactory)
        {
            this.prefab = prefab;
            this.spawnPoint = spawnPoint;
            this.input = input;
            this.weaponFactory = weaponFactory;
        }

        public Player Create()
        {
            Player player = GameObject.Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            player.Init(input, weaponFactory);
            return player;
        }
    }
}