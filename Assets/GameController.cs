using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject mapPrefab = null;
    [SerializeField]
    private int[] housesNumberPerLevel = null;
    [SerializeField]
    private bool[] extraHousePerLevel = null;
    [SerializeField]
    private float timeToRestartLevel = 1f;

    private GameObject map;

    private AnswerAnimController answerAn;

    private SetLevel uiSetLevel;

    private SetSceneColor uiSetSceneColor;

    private ExerciseBlock exercB;

    private soundController sound;

    private int winCount = 0;

    private int failCount = 0;

    public bool endGame { get; private set; }

    public int level { get; private set; }

    public void Start()
    {
        answerAn = GetComponentInChildren<AnswerAnimController>();

        GameObject ui = GameObject.FindWithTag( "UI" );

        uiSetLevel = ui.GetComponent<SetLevel>();

        uiSetSceneColor = ui.GetComponent<SetSceneColor>();

        exercB = GetComponent<ExerciseBlock>();

        sound = GameObject.FindWithTag( "Sound" ).GetComponent<soundController>();

        level = GameObject.FindWithTag("DataController")
            .GetComponent<DataController>().currentLevel;

        StartLevel();
    }

    private void StartLevel()
    {
        if (map != null)
            Destroy( map );

        endGame = false;

        map = Instantiate( mapPrefab, Vector3.zero, Quaternion.identity );

        MapController mapC = map.GetComponent<MapController>();

        mapC.housesNumber = housesNumberPerLevel[level - 1];

        mapC.dontVisitAHouse = extraHousePerLevel[level - 1];
    }

    public void Win()
    {
        sound.PlayAudioWin();

        endGame = true;

        failCount = 0;

        if (++winCount >= 3)
        {
            level++;

            uiSetLevel.AddLevel();

            if (level > 20)
                level = 20;

            winCount = 0;
        }

        uiSetSceneColor.SetNextBall( true );

        StartCoroutine( RestartLevel(true) );
    }

    public void Fail()
    {
        sound.PlayAudioLose();

        endGame = true;

        winCount = 0;

        if (++failCount >= 3)
        {
            level--;

            uiSetLevel.RemoveLevel();

            if (level < 1)
                level = 1;

            failCount = 0;
        }

        uiSetSceneColor.SetNextBall( false );

        StartCoroutine( RestartLevel(false) );
    }

    private IEnumerator RestartLevel(bool win)
    {
        if (win)
            answerAn.SetWinAnim();
        else
            answerAn.SetFailAnim();

        yield return new WaitForSeconds( timeToRestartLevel );

        if(!exercB.ExerciseBlockComplete())
            StartLevel();
    }
}
