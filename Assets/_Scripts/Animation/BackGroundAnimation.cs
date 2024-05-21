using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAnimation : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private MeshRenderer meshRenderer;

    private Vector2 meshOffSet;

    private void Start()
    {
        meshOffSet = meshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        meshRenderer.sharedMaterial.mainTextureOffset = meshOffSet;
    }

    private void Update()
    {
        var x = Mathf.Repeat(Time.time * speed, 1);
        var offset = new Vector2(x, meshOffSet.y);

            meshRenderer.sharedMaterial.mainTextureOffset = offset;

    }
}
