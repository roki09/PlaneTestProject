using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserCannon : MonoBehaviour
{
    [SerializeField] private Transform airplane;
    [SerializeField] private Transform cruiser;
    private Quaternion quaternion;

    private void Awake()
    {
        quaternion = this.transform.rotation;
    }

    //private void FixedUpdate()
    //{
    //    RotateToAirplane();
    //}

    private float CanculateIndex()
    {
        return -45 * airplane.position.x / this.transform.position.x;
    }
    private void RotateToAirplane()
    {
        var index = CanculateIndex();

        transform.rotation = Quaternion.Euler(quaternion.x, quaternion.y, index);

        if (transform.rotation.z >= 0)
            transform.rotation = Quaternion.Euler(quaternion.x, quaternion.y, 0);
        else if (transform.rotation.z <= -90)
            transform.rotation = Quaternion.Euler(quaternion.x, quaternion.y, -90);

    }
}
