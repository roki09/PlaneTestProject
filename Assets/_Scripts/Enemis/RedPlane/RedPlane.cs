using Architecture;
using Gameplay.Projectaile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Enemis
{
    public class RedPlane : EnemisBase, IDestroyed
    {
        public void DestroyEnemis()
        {
            ThrowStats();
            Destroy(this.gameObject);
        }

        public void GetDamage(MainAirplaneProjectaile projectaile)
        {
            this.health -= projectaile.GetDamageScore();
            projectaile.gameObject.SetActive(false);
            Debug.Log("Damage was taken");

            if (this.health <= 0)
            {
                DestroyEnemis();
            }
        }

        public void ThrowStats()
        {
            Stats.AddCoins(this, bounty);
            Debug.Log("Stats was throwing");
        }
    }

}
