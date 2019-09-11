using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSceneColor : MonoBehaviour
{
    [SerializeField]
    private Image[] balls;
    
    private int currentBall = 0;

    public void SetNextBall(bool win)
    {
        if (currentBall >= balls.Length) return;

        if (win == true)
            balls[currentBall].color = Color.green;
        else
            balls[currentBall].color = Color.red;

        currentBall++;
    }
}
