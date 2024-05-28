using Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PlayerInteractor : Interactor
{
    public MainAirplane player { get; private set; }

    public override void Initialize()
    {
        base.Initialize();

        var prefs = Resources.Load<GameObject>("Player");
        var go = GameObject.Instantiate(prefs);
        this.player = go.GetComponent<MainAirplane>();
    }
}
