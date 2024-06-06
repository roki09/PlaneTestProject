using Gameplay.Projectaile;
using Gameplay.Projectaile.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectaile : MonoBehaviour
{
    [SerializeField] private EnemisPool currentPool;
    [SerializeField] private ObjectPool<ProjectaileBase> projectailePoll;

    private void OnEnable()
    {
        //projectailePoll = currentPool.GetCurrentPool();
        StartCoroutine(Shot());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void CreateProjectaile()
    {
        var projectaile = currentPool.pool.GetFreeElement();
        projectaile.transform.position = new Vector3(this.transform.position.x, this.transform.position.y);
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
