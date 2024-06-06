using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SourceContainer
{
    private static GameObject redPlaneContainer;

    private const string tagRadPlane = "RadPlaneContainer";


    public static GameObject TakeRadPlaneContainer()
    {
        if (redPlaneContainer == null)
        {
            redPlaneContainer = GameObject.FindGameObjectWithTag(tagRadPlane);
        }
        return redPlaneContainer;
    }
}
