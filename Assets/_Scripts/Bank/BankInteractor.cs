using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


namespace Architecture
{
    public class BankInteractor : Interactor
    {
        private BankRepository repository;

        public int coins => this.repository.score;

        public override void OnCraete()
        {
            base.OnCraete();
            this.repository = Game.GetRepository<BankRepository>();
        }
        public override void Initialize()
        {
            Bank.Initialize(this);
        }

        public bool IsEnougthCoins(int value)
        {
            return coins >= value;
        }

        public void AddCoins(object sender, int value)
        {
            this.repository.score += value;
            this.repository.Save();
        }

        public void SpendCoins(object sender, int value)
        {
            this.repository.score -= value;
            this.repository.Save();
        }


    }

}
