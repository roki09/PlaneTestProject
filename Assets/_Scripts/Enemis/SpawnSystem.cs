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

    private string[] flyEnemisPath = {"Enemis", "Fly" };
    private string[] waterEnemisPath = { "Resources", "Enemis", "Water" };
    private string[] groundedEnemisPath = { "Resources", "Enemis", "Grounded" };

    private void OnEnable()
    {
        StartCoroutine(SpawnTimer());
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
    private void SpawnAirEnemis()
    {
        var thosepath = Path.Combine(flyEnemisPath);
        var path = Path.Combine(thosepath, flyEnemis[0]);
        var go = Resources.Load(path);
        Instantiate(go, airSpawnArray[Random.Range(0, 6)].transform);
    }
}
