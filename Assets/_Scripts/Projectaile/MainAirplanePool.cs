using Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAirplanePool : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int poolCount = 15;
    [SerializeField] private bool autoExpand = true;
    [SerializeField] private MainAirplaneProjectaile projectailePrefab;


    private ObjectPool<MainAirplaneProjectaile> pool;


    private void Start()
    {
        this.pool = new ObjectPool<MainAirplaneProjectaile>(this.projectailePrefab, this.poolCount, this.transform);
        this.pool.autoExpand = autoExpand;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            this.CreateProjectaile();
        }
    }

    private void CreateProjectaile()
    {
        StartCoroutine(Timer());
        var projectaile = pool.GetFreeElement();
        projectaile.transform.position = player.transform.position;
        projectaile.gameObject.SetActive(true);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
