using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExerciseBlock : MonoBehaviour
{
    [SerializeField]
    private int exerciseAmount = 10;

    private int currentExercise;

    private DataController dataC;

    private void Start()
    {
        dataC = GameObject.FindWithTag( "DataController" ).GetComponent<DataController>();
    }

    public bool ExerciseBlockComplete()
    {
        if(++currentExercise == exerciseAmount)
        {
            dataC.SetCurrentLevel(GetComponent<GameController>().level);

            dataC.SetCurrentScore(GameObject.FindWithTag( "UI" ).GetComponent<SetScore>().score);

            SceneManager.LoadScene( "End" );

            return true;
        }

        return false;
    }
}
