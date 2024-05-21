using Architecture;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


namespace SceneLogic
{
    public class Scene
    {
        private InteractorsBase interactorsBase;
        private RepositoryBase repositoryBase;
        private SceneConfig sceneConfig;

        public Scene(SceneConfig config) {
            this.sceneConfig = config;
            this.interactorsBase = new InteractorsBase(config);
            this.repositoryBase = new RepositoryBase(config);
        
        }
         
        public Coroutine InitializeAsync()
        {
            return Coroutines.StartRoutine(this.InitializeRoutine());
        }

        private IEnumerator InitializeRoutine()
        {
            interactorsBase.CreateAllInteractors();
            repositoryBase.CreateAllRepository();

            yield return null;
            interactorsBase.SendOnCreateToAllInteractors();
            repositoryBase.SendOnCreateToAllReposiitories();

            yield return null;
            interactorsBase.InitializeAllInteractors();
            repositoryBase.InitializeAllReposiitories();

            yield return null;
            interactorsBase.SendOnStartToAllInteractors();
            repositoryBase.SendOnStartToAllReposiitories();
        }

        public T GetRepository<T>() where T : Repository
        {
           return this.repositoryBase.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return this.interactorsBase.GetInteractor<T>();
        }
    }

}
