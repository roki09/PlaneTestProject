using Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture
{
    public class StatsRepository : Repository
    {
        private const string KEY = "STATS_KEY";
        private const string TOPSCORE = "TOPSTATS_KEY";
        public int score { get; set; }
        public int bestScore { get; set; }
        public List<EnemyStats> enemyStats { get; set; }

        public override void Initialize()
        {
            this.score = PlayerPrefs.GetInt(KEY, 0);
            this.bestScore = PlayerPrefs.GetInt(TOPSCORE, 0);
        }


        public override void SaveScore()
        {
            PlayerPrefs.SetInt(KEY, this.score);
        }

        public void SaveBestScore(int value)
        {
            PlayerPrefs.SetInt(TOPSCORE, value);
        }
        
        public void RemoveScore()
        {
            PlayerPrefs.SetInt(KEY, 0);
        }

        public void SaveEnemyStats()
        {
        }

    }

}
