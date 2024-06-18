using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] airSpawnArray;
    [SerializeField] private GameObject[] waterSpawnArray;
    [SerializeField] private GameObject[] groundSpawnArray;

    private string[] flyEnemis = { "RedPlane" };
    private string[] waterEnemis = {"Cruiser", "Aircraft Carrier" };

    private string[] flyEnemisPath = {"Enemis", "Fly" };
    private string[] waterEnemisPath = { "Enemis", "Water" };
    private string[] groundedEnemisPath = { "Resources", "Enemis", "Grounded" };

    private void OnEnable()
    {
        StartCoroutine(SpawnTimer());
        StartCoroutine(SpawnWater());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            SpawnAirEnemis();
        }
    }

    private IEnumerator SpawnWater()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            SpawnWaterEnemis();
        }
    }
    private void SpawnAirEnemis()
    {
        var thosepath = Path.Combine(flyEnemisPath);
        var path = Path.Combine(thosepath, flyEnemis[0]);
        var go = Resources.Load(path);
        Instantiate(go, airSpawnArray[Random.Range(0, 6)].transform);
    }
    private void SpawnWaterEnemis()
    {
        var thosepath = Path.Combine(waterEnemisPath);
        var path = Path.Combine(thosepath, waterEnemis[Random.Range(0, 2)]);
        var go = Resources.Load(path);
        Instantiate(go, waterSpawnArray[0].transform);
    }



}
