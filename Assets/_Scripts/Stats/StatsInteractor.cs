using Architecture.SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


namespace Architecture
{
    public class StatsInteractor : Interactor
    {
        private StatsRepository repository;

        public int score => this.repository.score;
        public int bestScore => this.repository.bestScore;

        public List<EnemyStats> enemyStats => this.repository.enemyStats;

        public override void OnCraete()
        {
            base.OnCraete();
            this.repository = Game.GetRepository<StatsRepository>();
        }
        public override void Initialize()
        {
            Stats.Initialize(this);
        }


        public void CompareScore()
        {
            if (this.score > this.bestScore)
            {
                repository.SaveBestScore(this.score);
            }
        }

        public void AddScore(object sender, int value)
        {
            this.repository.score += value;
        }


        public void AddEnemyStats(object sender, EnemyStats exampleStats)
        {
            if (enemyStats == null)
            {
                enemyStats.Add(exampleStats);
                return;
            }

            foreach (var stats in enemyStats)
            {
                if (stats.name == exampleStats.name)
                {
                    stats.value++;
                    return;
                }
            }

            enemyStats.Add(exampleStats);
        }

        public void AddEnemyStatsOnLoad(List<EnemyStats> enemyStatsExample)
        {
            if (enemyStatsExample == null)
                return;

            foreach (var stats in enemyStatsExample)
            {
                if (stats != null)
                    enemyStats.Add(stats);
            }
        }


    }

}
