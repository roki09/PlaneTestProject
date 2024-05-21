using Architecture;
using SceneLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game
{

    public static event Action OnGameInitializeEvent;
    public static SceneManagerBase sceneManager { get; private set; }

    public static void Run()
    {
        sceneManager = new SceneManagerExample();
        Coroutines.StartRoutine(InitializeGameRoutine());
    }

    private static IEnumerator InitializeGameRoutine()
    {
        sceneManager.InitScenesMap();
        yield return sceneManager.LoadCurrentSceneAsync();
        OnGameInitializeEvent?.Invoke();
    }

    public static T GetInverator<T>() where T : Interactor
    {
        return sceneManager.GetInteractor<T>();
    }

    public static T GetRepository<T>() where T : Repository
    {
        return sceneManager.GetRepository<T>();
    }
}
