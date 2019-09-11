using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    private List<Vector2> route;

    private GameController gameC;
    
    private void Start()
    {
        route = new List<Vector2>();

        gameC = GameObject.FindWithTag( "GameController" )
                    .GetComponent<GameController>();
    }

    public void AddHouse(Vector2 pos)
    {
        route.Add(pos);
    }

    public void RemoveRoute(Vector2 pos)
    {
        route.Remove( pos );
    }

    public bool CheckRoute(Vector2 pos)
    {
        if (route.Count > 0 && pos == route[0])
        {
            RemoveRoute( pos );

            if (route.Count == 0)
                gameC.Win();
            else
                GameObject.FindWithTag( "Sound" )
                .GetComponent<soundController>().PlayAudioClick();

            return true;
        }
        
        gameC.Fail();

        return false;
    }
}
