using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNextHouse : MonoBehaviour
{
    private MapController mapC;

    private GameObject aStar;

    private RouteController route;

    void Start()
    {
        GameObject map = GameObject.FindWithTag( "Map" );

        mapC = map.GetComponent<MapController>();

        route = map.GetComponent<RouteController>();

        aStar = GameObject.FindWithTag( "AStar" );

        Vector2 pos = new Vector2( transform.position.x - 0.5f, transform.position.y - 0.5f );

        route.AddHouse( pos );

        SelectNext();
    }

    public void SelectNext()
    {
        List<Vector2> housesPos = mapC.housesPos;

        if(housesPos.Count == 0)
        {
            StartCoroutine(EndHouses());

            return;
        }

        int index = Random.Range( 0, housesPos.Count );

        CancelWallOnHousePos( housesPos[index] );

        CreateNewObjectAndSetAStarTarget( housesPos[index] );

        route.AddHouse( housesPos[index] );

        housesPos.RemoveAt( index );
    }

    private void CancelWallOnHousePos( Vector2 pos)
    {
        int x = Mathf.RoundToInt( pos.x );
        int y = Mathf.RoundToInt( pos.y );

        aStar.GetComponent<Grid>().nodeArray[x, y].isWall = false;
    }

    private void CreateNewObjectAndSetAStarTarget(Vector2 pos)
    {
        GameObject obj, nextHouse = GameObject.Find( "NextHouse" );

        if (nextHouse)
            obj = nextHouse;
        else
            obj = new GameObject { name = "NextHouse" };

        obj.transform.position = new Vector2(pos.x + 0.5f, pos.y + 0.5f);

        aStar.GetComponent<AStar>().targetPos = obj.transform;
    }

    private IEnumerator EndHouses()
    {
        yield return new WaitForSeconds(0.5f);

        GetComponent<Animator>().SetTrigger( "hidden" );

        Destroy( gameObject, 1f );
    }
}
