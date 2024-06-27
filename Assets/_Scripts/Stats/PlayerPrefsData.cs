using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture.SaveSystem
{
    [Serializable]
    public class PlayerPrefsData
    {
        public int bestScore;
        public List<EnemyStats> enemyStats;
    }

}
