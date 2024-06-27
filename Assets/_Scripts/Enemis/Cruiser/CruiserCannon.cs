using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserCannon : MonoBehaviour
{
    [SerializeField] MainAirplane player;

    private void OnEnable()
    {
        player = FindAnyObjectByType<MainAirplane>();
    }

    private void Update()
    {
        Turn();
    }


    private void Turn()
    {
        var direction = player.transform.position - transform.position;
        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
