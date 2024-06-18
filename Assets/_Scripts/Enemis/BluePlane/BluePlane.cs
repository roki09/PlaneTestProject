using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlane : EnemisBase
{
    [SerializeField] ArchTester archTester;
    private Vector3 mainPlanePosition;

    private void OnEnable()
    {
        mainPlanePosition = archTester.player.transform.position;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate((mainPlanePosition - transform.position).normalized * 1 * Time.deltaTime);
    }
}
