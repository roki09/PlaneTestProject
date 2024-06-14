using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Gameplay.Projectaile
{
    public class MainAirplaneProjectaile : ProjectaileBase
    {
        private void Update()
        {
            Move();
        }

        public override void Move()
        {
            transform.Translate(Vector3.right * this.GetCurrentSpeed() * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out EnemisBase destroyed))
            {
                destroyed.GetDamage(this);
            }
        }
    }

}
