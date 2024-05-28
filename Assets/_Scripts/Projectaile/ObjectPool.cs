using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Gameplay.Projectaile.Pool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        public T prefab { get; }

        public bool autoExpand { get; set; }

        public Transform container { get; }

        private List<T> pool;

        public ObjectPool(T prefab, int count)
        {
            this.prefab = prefab;
            this.container = null;

        }

        public ObjectPool(T prefab, int count, Transform container)
        {
            this.prefab = prefab;
            this.container = container;

            this.CreatePool(count);
        }


        private void CreatePool(int pool)
        {
            this.pool = new List<T>();

            for (int i = 0; i < pool; i++) { }
        }

        private T CreateObject (bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(this.prefab, this.container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            this.pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var item in pool)
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    element = item;
                    item.gameObject.SetActive(true);
                    return true;
                }

            }
                element = null;
                return false;
        }

        public T GetFreeElement()
        {
            if(this.HasFreeElement(out var element))
                return element;

            if(this.autoExpand)
                return this.CreateObject(true);

            throw new System.Exception($"There if no free elements in pool of type {typeof(T)}");
        }
    }

}
