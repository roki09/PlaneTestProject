using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class MiniPlane : MonoBehaviour
{
    private string[] bluePlanePath = { "Enemis","Fly", "BluePlane" };

    private void OnEnable()
    {
        Jump();
    }
    public void SpawnBluePlane()
    {
        var path = Path.Combine(bluePlanePath);
        var go = Resources.Load(path);
        var plane = Instantiate(go);

        var planeTransform = plane.GetComponent<Transform>();
        planeTransform.transform.position = this.transform.position;

        Destroy(this.gameObject);
        
    }

    private void Jump()
    {
        var xDelta = Random.Range(3.0f, 5.0f);
        var yDelta = Random.Range(2.0f, 3f);
        var jumpPower = Random.Range(1f, 4f);

        Vector3 targerPos = new Vector3(transform.position.x - xDelta, transform.position.y + yDelta, transform.position.z);
        transform.DOJump(targerPos, 3, 1, 5)
            .SetLink(gameObject);
    }
}
