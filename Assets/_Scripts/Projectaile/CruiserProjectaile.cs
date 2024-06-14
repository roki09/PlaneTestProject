using Gameplay.Projectaile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserProjectaile : ProjectaileBase
{
    [SerializeField] private MainAirplane mainAirplane;
    private float[] airplanePosition = new float[2];


    private void OnEnable()
    {
        mainAirplane = FindAnyObjectByType<MainAirplane>();
        airplanePosition[0] = mainAirplane.gameObject.transform.position.x;
        airplanePosition[1] = mainAirplane.gameObject.transform.position.y;

    }

    private void Update()
    {
        Move();
    }


    public override void Move()
    {
        transform.Translate(new Vector2(airplanePosition[0], airplanePosition[1]) * this.GetCurrentSpeed() * Time.deltaTime);
    }

}
