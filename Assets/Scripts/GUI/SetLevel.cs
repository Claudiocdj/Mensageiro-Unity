using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevel : MonoBehaviour
{
    [SerializeField]
    private Text levelText;

    public void Start()
    {
        int level = GameObject.FindWithTag( "DataController" )
            .GetComponent<DataController>().currentLevel;

        levelText.text = level.ToString();
    }

    public void AddLevel()
    {
        int level = int.Parse( levelText.text ) + 1;

        levelText.text = level.ToString();
    }

    public void RemoveLevel()
    {
        int level = int.Parse( levelText.text ) - 1;

        levelText.text = level.ToString();
    }
}
