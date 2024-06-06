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

        public Dictionary<string, int> killsStats => this.repository.killsStats;

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
            if(this.score > this.bestScore)
            {
                repository.SaveBestScore(this.score);
            }
        }

        public void AddScore(object sender, int value)
        {
            this.repository.score += value;
        }

        public void AddEnemyStats(object sender, string name)
        {
            if (killsStats.ContainsKey(name))
                killsStats[name]++;
            else
                killsStats.Add(name, 1);
        }


    }

}
