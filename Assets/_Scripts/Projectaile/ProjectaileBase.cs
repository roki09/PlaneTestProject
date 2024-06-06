using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gameplay.Projectaile
{
    public abstract class ProjectaileBase : MonoBehaviour
    {

        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        [SerializeField] private int damage;

        private void OnEnable()
        {
            StartCoroutine(LifeTime());
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSecondsRealtime(lifeTime);

            this.gameObject.SetActive(false);
        }

        public abstract void Move();

        public int GetDamageScore()
        {
            return damage;
        }

        public float GetCurrentSpeed()
        {
            return speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out MainAirplane mainAirplane))
            {
                mainAirplane.TakingDamage(damage);
            }
        }

    }

}
