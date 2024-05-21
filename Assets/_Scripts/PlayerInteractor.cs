using Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : Interactor
{
    public Player player {  get; private set; }

    public override void Initialize()
    {
        base.Initialize();

        var go = new GameObject("Player");
        this.player = go.AddComponent<Player>();
    }
}
