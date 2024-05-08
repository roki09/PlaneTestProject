using Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture
{
    public class BankRepository : Repository
    {
        private const string KEY = "BANK_KEY";
        public int score { get; set; }
        public override void Initialize()
        {
            this.score = PlayerPrefs.GetInt(KEY, 0);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY, this.score);
        }
    }

}
