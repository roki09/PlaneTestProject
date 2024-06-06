
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Stats = Architecture.Stats;

namespace UI
{
    public class StatisticsСounter : MonoBehaviour
    {
        private TextMeshProUGUI statsText;
        private int score
        {
            get
            {
                return Stats.score;
            }
            set
            {
                statsText.text = Stats.score.ToString();
            }

        }

        private void OnEnable()
        {
            statsText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (Stats.isInitialized)
                score = Stats.score;
        }
    }
}
