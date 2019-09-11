using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<Vector2> housesPos;
    public int housesNumber = 3;
    public bool dontVisitAHouse = false;

    [SerializeField]
    private GameObject housePrefab = null;
    [SerializeField]
    private int Xsize = 6;
    [SerializeField]
    private int Ysize = 8;

    private List<Vector2> neighbors;
    private List<Vector2> empty;

    void Start()
    {
        CreateGrid();

        AddHouses();
    }
    
    private void CreateGrid()
    {
        empty = new List<Vector2>();

        neighbors = new List<Vector2>();

        housesPos = new List<Vector2>();
        
        for (int i = 0; i < Xsize; i++)
            for (int j = 0; j < Ysize; j++)
                empty.Add( new Vector2( i, j ) );
    }

    private void AddHouses()
    {
        int houses = housesNumber;

        Vector2 pos;

        while (houses-- > 0)
        {
            if (empty.Count > 0)
            {
                pos = SelectPos( empty );

                AddNeighbors( pos );
            }
            else
                pos = SelectPos( neighbors );

            Vector2 screenPos = new Vector2(pos.x + 0.5f, pos.y + 0.5f);

            GameObject square = Instantiate( housePrefab, screenPos, Quaternion.identity );

            square.transform.parent = transform;

            housesPos.Add( pos );
        }

        GameObject.FindWithTag("AStar").GetComponent<Grid>().RestartGrid();

        if (dontVisitAHouse)
            housesPos.RemoveAt( 1 );
    }

    private Vector2 SelectPos(List<Vector2> list)
    {
        int index = Random.Range( 0, list.Count );

        Vector2 pos = list[index];

        list.Remove( pos );

        return pos;
    }

    private void AddNeighbors(Vector2 pos)
    {
        SwapEmptyNeighbors( new Vector2( pos.x + 1, pos.y ) );

        SwapEmptyNeighbors( new Vector2( pos.x - 1, pos.y ) );

        for (int i = -1; i <= 1; i++)
        {
            SwapEmptyNeighbors( new Vector2( pos.x + i, pos.y + 1 ) );

            SwapEmptyNeighbors( new Vector2( pos.x + i, pos.y - 1 ) );
        }
    }

    private void SwapEmptyNeighbors(Vector2 pos)
    {
        if (empty.Contains(pos))
        {
            neighbors.Add( pos );

            empty.Remove( pos );
        }
    }
}
