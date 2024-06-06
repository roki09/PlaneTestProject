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
        [SerializeReference] private Transform container;


        public ObjectPool<ProjectaileBase> pool;


        private void OnEnable()
        {
            this.pool = new ObjectPool<ProjectaileBase>(this.projectailePrefab, this.poolCount, this.container);
            this.pool.autoExpand = autoExpand;

        }

        //private void OnDestroy()
        //{
        //    StopAllCoroutines();
        //}

        //private void CreateProjectaile()
        //{
        //    var projectaile = pool.GetFreeElement();
        //    projectaile.transform.position = new Vector3(this.transform.position.x, this.transform.position.y);
        //    projectaile.gameObject.SetActive(true);
        //}

        //private IEnumerator Shot()
        //{
        //    while (true)
        //    {
        //        yield return new WaitForSecondsRealtime(3);
        //        CreateProjectaile();
        //    }
        //}

        public ObjectPool<ProjectaileBase> GetCurrentPool()
        {
            return pool;
        }


    }
}
