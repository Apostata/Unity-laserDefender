using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKepper : MonoBehaviour

{
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    int score = 0;

    public int Score { get => score; set { 
        score = Mathf.Clamp(value, 0, int.MaxValue);
        scoreText.text = score.ToString().PadLeft(8, '0');
    }}
}
