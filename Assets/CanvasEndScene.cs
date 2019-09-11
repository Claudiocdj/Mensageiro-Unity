using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasEndScene : MonoBehaviour
{
    [SerializeField]
    private Text score;

    void Start()
    {
        DataController dataC = GameObject.FindWithTag( "DataController" )
            .GetComponent<DataController>();

        score.text = dataC.currentScore.ToString();
    }
}
