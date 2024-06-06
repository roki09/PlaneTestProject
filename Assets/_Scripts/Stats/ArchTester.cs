using Architecture;
using SceneLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArchTester : MonoBehaviour
{
    public MainAirplane player;
    [SerializeField] private Canvas canvas;

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

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        canvas.gameObject.SetActive(true);
    }
}
