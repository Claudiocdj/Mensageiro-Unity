using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private int baseScorePoints = 100;

    public int score { get; private set; }

    public void AddScore(int level)
    {
        score = Mathf.RoundToInt(baseScorePoints * level * 1.5f) + int.Parse(scoreText.text);

        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        scoreText.text = "";

        score = 0;
    }
}
