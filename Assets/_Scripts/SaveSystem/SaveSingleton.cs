using Architecture;
using Architecture.SaveSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Architecture.SaveSystem
{
    public class SaveSingleton : MonoBehaviour
    {
        public static SaveSingleton Instance { get; private set; }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
                return;
            }
            //Destroy(gameObject);
        }

        private const string saveKey = "mainSave";

        public void Save()
        {
            SaveManager.Save(saveKey, GetSaveSnapShot());
        }

        public void Load()
        {
            var data = SaveManager.Load<SaveSystem.PlayerPrefsData>(saveKey);

            if (data != null)
                Stats.AddEnemyStatsOnLoad(data.enemyStats);
        }

        private SaveSystem.PlayerPrefsData GetSaveSnapShot()
        {
            var data = new SaveSystem.PlayerPrefsData()
            {
                enemyStats = Stats.enemyStats,
                
                bestScore = Stats.bestScore,
            };
            return data;
        }



    }

}
