using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Gameplay
{

    public class MainAirplaneProjectaile : MonoBehaviour
    {

        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;

        private void OnEnable()
        {
            StartCoroutine(LifeTime());
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSecondsRealtime(lifeTime);

            this.gameObject.SetActive(false);
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

}
