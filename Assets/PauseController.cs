using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen = null;

    private void Start()
    {
        pauseScreen.SetActive( false );
    }

    public void OnClickPauseControl(bool pause)
    {
        pauseScreen.SetActive( pause );

        if (pause)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
