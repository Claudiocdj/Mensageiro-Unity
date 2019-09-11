using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickCheckRoute : MonoBehaviour
{
    private RouteController routeC;

    private Animator anim;

    private GameController gameC;

    private Vector2 pos;
    
    private void Start()
    {
        gameC = GameObject.FindWithTag( "GameController" ).GetComponent<GameController>();

        routeC = GameObject.FindWithTag( "Map" ).GetComponent<RouteController>();

        pos = new Vector2( transform.position.x - 0.5f, transform.position.y - 0.5f );

        anim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (!GameObject.FindWithTag( "Player" ) && gameC.endGame == false)
        {
            if (anim)
                anim.SetTrigger( "hidden" );

            if(routeC.CheckRoute( pos ))
                GameObject.FindWithTag( "UI" )
                .GetComponent<SetScore>().AddScore( gameC.level );
        }
    }
}
