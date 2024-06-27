using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BluePlane : EnemisBase
{
    private MainAirplane player;

    private void OnEnable()
    {
        this.speed = Random.Range(1f, 1.5f);
    }
    private void Update()
    {
        //Turn();
        Move();
    }
    private void Move()
    {
       transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    //private void Turn()
    //{
    //    if (player == null)
    //        return;

    //    var direction = player.transform.position - transform.position;
    //    var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0, 0, angle);
    //}
}
