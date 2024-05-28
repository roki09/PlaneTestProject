using Gameplay.Projectaile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Projectaile.Pool
{
    public class EnemisPool : MonoBehaviour
    {
        [SerializeField] private int poolCount = 15;
        [SerializeField] private bool autoExpand = true;
        [SerializeField] private ProjectaileBase projectailePrefab;


        private ObjectPool<ProjectaileBase> pool;


        private void Start()
        {
            this.pool = new ObjectPool<ProjectaileBase>(this.projectailePrefab, this.poolCount, this.transform);
            this.pool.autoExpand = autoExpand;
            StartCoroutine(Shot());

        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void CreateProjectaile()
        {
            var projectaile = pool.GetFreeElement();
            projectaile.transform.position = new Vector3(this.transform.position.x + 0.2f, this.transform.position.y + 0.2f);
            projectaile.gameObject.SetActive(true);
        }

        private IEnumerator Shot()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(3);
                CreateProjectaile();
            }
        }


    }
}
