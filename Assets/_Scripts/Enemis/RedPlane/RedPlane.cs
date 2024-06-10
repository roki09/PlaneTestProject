using Architecture;
using Gameplay.Projectaile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Enemis
{
    public class RedPlane : EnemisBase, IDestroyed
    {
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            transform.Translate(Vector3.left * 1 * Time.deltaTime);
        }
        public void DestroyEnemis()
        {
            ThrowStats();
            Destroy(this.gameObject);
        }

        public void DestroyWitoutStats()
        {
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
            Stats.AddEnemyStats(this, enemyStats);
            Debug.Log("Stats was throwing");
        }
    }

}
