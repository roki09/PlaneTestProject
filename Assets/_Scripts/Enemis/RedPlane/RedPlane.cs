using Architecture;
using Gameplay.Projectaile;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gameplay.Enemis
{
    public class RedPlane : EnemisBase
    {
        private void OnEnable()
        {
            this.speed = Random.Range(0.7f, 2.0f);
        }
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

}
