using Architecture;
using SceneLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneLogic
{
    public class SceneConfigExample : SceneConfig
    {

        public const string SCENE_NAME = "SampleScene";
        public override string sceneName => SCENE_NAME;

        // Добавляем все интеракторы
        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            var interactorsMap = new Dictionary<Type, Interactor>();

            this.CreateInteractor<StatsInteractor>(interactorsMap);
            this.CreateInteractor<PlayerInteractor>(interactorsMap);

            return interactorsMap;
        }

        // Добавляем все репозитории
        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            var repositoriesMap = new Dictionary<Type, Repository>();
            
            this.CreateRepository<StatsRepository>(repositoriesMap);

            return repositoriesMap;
        }
    }

}
