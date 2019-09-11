using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapController))]
public class SetPlayerPrefab : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab = null;

    private MapController mapC;

    private void Start()
    {
        mapC = GetComponent<MapController>();

        SelectFirstPosition();
    }

    private void SelectFirstPosition()
    {
        int index = Random.Range( 0, mapC.housesPos.Count );

        Vector2 pos = new Vector2( mapC.housesPos[index].x + 0.5f,
            mapC.housesPos[index].y + 0.5f );

        GameObject player = Instantiate( playerPrefab, pos, Quaternion.identity );

        SetPlayerOnAStar( player );

        mapC.housesPos.RemoveAt( index );
    }

    private void SetPlayerOnAStar(GameObject player) {
        GameObject AStar = GameObject.FindWithTag( "AStar" );

        if (AStar)
            AStar.GetComponent<AStar>().startPos = player.transform;
    }
}
