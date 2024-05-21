using Architecture;
using SceneLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchTester : MonoBehaviour
{
    private Player player;

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
        if (!Bank.isInitialized)
        {
            Debug.Log("Bank not Initialize yet in Update");
            return;
        }

        if (this.player == null)
            return;

        Debug.Log($"Player position: {this.player.transform.position}");
      
        if (Input.GetKeyDown(KeyCode.A))
        {
            Bank.AddCoins(this, 5);
            Debug.Log($"Coins added (5), {Bank.coins}");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Bank.SpendCoins(this, 5);
            Debug.Log($"Coins spended (5), {Bank.coins}");
        }
    }
}
