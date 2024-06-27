using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Gameplay.Enemis
{
    public class AircraftCarrier : EnemisBase
    {

        private string[] flyEnemisPath = { "Enemis", "Fly", "MiniPlane" };

        
        private void Start()
        {
            StartCoroutine(Timer());
            this.speed = Random.Range(1, 1.2f);
        }

        private void Update()
        {
            Move();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void Move()
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        private void SpawnPlane()
        {
            var path = Path.Combine(flyEnemisPath);
            var go = Resources.Load(path);
            Instantiate(go, this.transform);
        }

        private IEnumerator Timer()
        {
            for (int i = 0; i < 2; i++)
            {
                yield return new WaitForSeconds(3);
                SpawnPlane();
                i++;
            }
        }
    }
}
