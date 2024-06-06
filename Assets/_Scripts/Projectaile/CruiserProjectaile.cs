using Gameplay.Projectaile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserProjectaile : ProjectaileBase
{
    [SerializeField] private MainAirplane mainAirplane;

    private Vector3 planePosition;

    private void OnEnable()
    {
        mainAirplane = FindAnyObjectByType<MainAirplane>();
        planePosition = mainAirplane.transform.position;
    }

    private void Update()
    {
        Move();
    }


    public override void Move()
    {
        transform.Translate(-planePosition * this.GetCurrentSpeed() * Time.deltaTime);
    }

}
