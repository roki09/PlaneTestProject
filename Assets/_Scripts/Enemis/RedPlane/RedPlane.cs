using Architecture;
using Gameplay.Projectaile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Enemis
{
    public class RedPlane : EnemisBase
    {
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
