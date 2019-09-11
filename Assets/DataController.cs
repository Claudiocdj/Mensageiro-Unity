using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController instance = null;
    
    public int currentScore;

    public int currentLevel;

    public int highScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy( gameObject );

        DontDestroyOnLoad( gameObject );

        highScore = PlayerPrefs.GetInt( "HighScore", 0 );

        currentScore = 0;

        currentLevel = PlayerPrefs.GetInt( "Level", 1 );
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;

        PlayerPrefs.SetInt( "Level", level );
    }

    public void SetCurrentScore(int score)
    {
        currentScore = score;

        CheckHighScore();
    }
    
    private void CheckHighScore()
    {
        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt( "HighScore", currentScore );

            highScore = currentScore;
        }
    }
}
