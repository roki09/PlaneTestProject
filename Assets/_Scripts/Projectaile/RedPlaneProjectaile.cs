
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Projectaile
{
    public class RedPlaneProjectaile : ProjectaileBase
    {

        private void Update()
        {
            Move();
        }
        public override void Move()
        {
            transform.Translate(Vector3.up * this.GetCurrentSpeed() * Time.deltaTime);
        }
    }

}
