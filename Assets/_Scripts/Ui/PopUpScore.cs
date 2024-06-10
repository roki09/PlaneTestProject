using Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PopUpScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TopScoretext;
    [SerializeField] private TextMeshProUGUI CurrentScoretext;
    [SerializeField] private TextMeshProUGUI newsc;


    private void OnEnable()
    {
        if(Stats.score > Stats.bestScore)
            newsc.gameObject.SetActive(true);
        Stats.CompareScore();
        TopScoretext.text = $"Best Score:{Stats.bestScore}";
        CurrentScoretext.text = $"Curernt Score:{Stats.score}";
    }
}
