using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFirstScene : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text level;

    void Start()
    {
        DataController dataC = GameObject.FindWithTag( "DataController" )
            .GetComponent<DataController>();

        score.text = dataC.highScore.ToString();

        level.text = dataC.currentLevel.ToString();
    }
}
