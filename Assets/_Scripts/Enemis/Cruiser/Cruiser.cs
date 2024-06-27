using Architecture;
using Gameplay;
using Gameplay.Projectaile;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Enemis
{
    public class Cruiser : EnemisBase
    {
        private void OnEnable()
        {
            this.speed = Random.Range(0.5f, 1.5f);
        }
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            transform.Translate(Vector3.left * 1 * Time.deltaTime);
        }
    }

}
