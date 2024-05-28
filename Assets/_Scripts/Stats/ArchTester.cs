using Architecture;
using SceneLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchTester : MonoBehaviour
{
    private MainAirplane player;

    private void Start()
    {
        Game.Run();
        Game.OnGameInitializeEvent += OnGameInitialized;
    }
    
    private void OnGameInitialized()
    {
        Game.OnGameInitializeEvent -= OnGameInitialized;
        var playerInteractor = Game.GetInverator<PlayerInteractor>();
        this.player = playerInteractor.player;
    }

    private void Update()
    {
        if (!Stats.isInitialized)
        {
            Debug.Log("Bank not Initialize yet in Update");
            return;
        }

        if (this.player == null)
            return;

        Debug.Log($"Player position: {this.player.transform.position}");
      
    }
}
