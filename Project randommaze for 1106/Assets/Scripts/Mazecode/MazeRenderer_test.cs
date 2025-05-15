using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer_test : MonoBehaviour
{

    [SerializeField]
    [Range(1, 50)]
    private int width = 10;

    [SerializeField]
    [Range(1, 50)]
    private int height = 10;

    [SerializeField]
    private int summonx = 0;

    [SerializeField]
    private int summony = 0;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform wallPrefab = null;

    [SerializeField]
    private Transform floorPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);
    }

    private void Draw(WallState[,] maze) 
    {

        var floor = Instantiate(floorPrefab, transform);
        floor.localScale = new Vector3(width/7.9f, 1, height/7.9f);

        for (int i=0; i < width; ++i) {
            for (int j=0; j < height; ++j) {
                var cell = maze[i,j];
                var position = new Vector3(-width/2 + i + summonx, 0, -height/2 + j + summony);

                if(cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size/2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if(cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size/2, 0, 0);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT)){
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size/2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN)){
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size/2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }

        /*GameObject[] allWalls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wall in allWalls)
        {
            Vector3 wallPosition = wall.transform.position;
            Quaternion wallRotation = wall.transform.rotation;

            if (IsEdgeWall(wallPosition, wallRotation))
            {
                Destroy(wall);
            }
        }*/
    }

    /*bool IsEdgeWall(Vector3 position, Quaternion rotation)
    {
        if (rotation.y == 90 && (position.x + summonx == -15.5 || position.x + summonx == 15.5) || rotation.y == 0 && (position.z + summony == -15.5 || position.z + summony == 15.5))
        {
            Debug.Log(position.x);
            return true;
        }

        return false;
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
