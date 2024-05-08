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

        public BankInteractor(BankRepository repository)
        {
            this.repository = repository;
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


    }

}
