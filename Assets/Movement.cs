using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float freezeTime;
    
    private float timer;            
    private float inverseMoveTime;
    private GameObject AStar;

    [SerializeField]
    private bool canMove = true;

    void Start()
    {
        timer = freezeTime;

        inverseMoveTime = 1f / speed;

        AStar = GameObject.FindWithTag( "AStar" );
    }
    
    void Update()
    {
        if (canMove){
            if(timer < 0)
            {
                List<Node> path = new List<Node>( AStar.GetComponent<Grid>().finalPath );

                Move( path );

                timer = freezeTime;
            }
            else
                timer -= Time.deltaTime;
        }
    }

    private void Move( List<Node> path )
    {
        canMove = false;

        StartCoroutine( MovementCoroutine(path) );
    }

    private IEnumerator MovementCoroutine( List<Node> path )
    {
        Vector2 origin = transform.position;

        Vector3 end;

        while (path.Count > 0)
        {
            end = new Vector2( path[0].position.x, path[0].position.y);

            path.RemoveAt(0);

            float sqrRemainingDistance = ( transform.position - end ).sqrMagnitude;

            while (sqrRemainingDistance > float.Epsilon)
            {
                Vector3 newPostion = Vector3.MoveTowards( transform.position, end, speed * Time.deltaTime );

                transform.position = newPostion;

                sqrRemainingDistance = ( transform.position - end ).sqrMagnitude;

                yield return null;
            }
        }

        int x = Mathf.RoundToInt( origin.x - 0.5f );
        int y = Mathf.RoundToInt( origin.y - 0.5f );

        AStar.GetComponent<Grid>().nodeArray[x, y].isWall = true;

        GetComponent<SelectNextHouse>().SelectNext();

        canMove = true;
    }
}
