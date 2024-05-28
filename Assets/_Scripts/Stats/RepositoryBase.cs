using Architecture;
using SceneLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture
{
    public class RepositoryBase
    {
        private Dictionary<Type, Repository> repositoryMap;
        private SceneConfig sceneConfig;



        public RepositoryBase(SceneConfig sceneConfig)
        {
            this.sceneConfig = sceneConfig;
            this.repositoryMap = new Dictionary<Type, Repository>();
        }


        public void CreateAllRepository()
        {
            this.repositoryMap = this.sceneConfig.CreateAllRepositories();
        }


        private void CreateRepository<T>() where T : Repository, new()
        {
            var repository = new T();
            var type = typeof(T);
            this.repositoryMap[type] = repository;
        }

        public void SendOnCreateToAllReposiitories()
        {
            var allRepositories = repositoryMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnCreate();
            }
        }

        public void InitializeAllReposiitories()
        {
            var allRepositories = repositoryMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.Initialize();
            }
        }
        public void SendOnStartToAllReposiitories()
        {
            var allRepositories = repositoryMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnStart();
            }
        }

        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T)this.repositoryMap[type];
        }
    }

}
