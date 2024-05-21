using Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLogic
{
    public abstract class SceneManagerBase
    {
        public Scene scene { get; private set; }

        public bool isLoading { get; private set; }

        protected Dictionary<string, SceneConfig> sceneConfigMap;

        public SceneManagerBase() {
            this.sceneConfigMap = new Dictionary<string, SceneConfig>();
        }

        public abstract void InitScenesMap();




        private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
        {
            this.isLoading = true;

            yield return Coroutines.StartRoutine(this.InitializeSceneRoutine(sceneConfig));

            this.isLoading = false;
        }


        public Coroutine LoadCurrentSceneAsync()
        {
            if (this.isLoading)
                throw new System.Exception("Scene is loading now");

            var sceneName = SceneManager.GetActiveScene().name;
            var config = this.sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(this.LoadCurrentSceneRoutine(config));
        }



        private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
        {
            this.isLoading = true;

            yield return Coroutines.StartRoutine(this.LoadSceneRoutine(sceneConfig));
            yield return Coroutines.StartRoutine(this.InitializeSceneRoutine(sceneConfig));

            this.isLoading = false;
        }
        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if (this.isLoading)
                throw new System.Exception("Scene is loading now");

            var config = this.sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(this.LoadNewSceneRoutine(config));
        }



        private IEnumerator LoadSceneRoutine (SceneConfig sceneConfig)
        {
            var async = SceneManager.LoadSceneAsync(sceneConfig.sceneName);
            async.allowSceneActivation = false;

            while(async.progress < 0.9f)
            {
                yield return null;
            }

            async.allowSceneActivation = true;
        }

        private IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
        {
            this.scene = new Scene(sceneConfig);
            yield return this.scene.InitializeAsync();
        }


        public T GetRepository<T>() where T : Repository
        {
            return this.scene.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return this.scene.GetInteractor<T>();
        }
    }

}
