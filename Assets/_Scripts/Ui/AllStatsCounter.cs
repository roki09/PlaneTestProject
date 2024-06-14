using System.Collections;
using Architecture;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Stats = Architecture.Stats;
using System.Text;

public class AllStatsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statsText;

    private void OnEnable()
    {
        ParseStats();
    }

    private void ParseStats()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in Stats.enemyStats)
        {
            sb.Append($"{item.key}: {item.value}\n");
        }
        statsText.text = sb.ToString();
    }
}
