using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    private Text num;

    private void Start()
    {
        StartCoroutine( CountDownCoroutine() );
    }

    private IEnumerator CountDownCoroutine()
    {
        while( int.Parse(num.text) > 1)
        {
            yield return new WaitForSeconds( 1f );

            num.text = ( int.Parse( num.text ) - 1 ).ToString();

            GetComponentInChildren<Animator>().SetTrigger( "change" );
        }

        yield return new WaitForSeconds( 1f );

        SceneManager.LoadScene( "Game" );
    }
}
