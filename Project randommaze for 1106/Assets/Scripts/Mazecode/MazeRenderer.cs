using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class MazeRenderer : MonoBehaviour
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

        List<Vector3> wallCoordinates = new List<Vector3>();

        // 모든 GameObject를 배열로 가져옵니다.
        GameObject[] wallObjects = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wallObject in wallObjects)
        {
            // 각 프리팹의 Transform 컴포넌트를 가져와서 좌표를 리스트에 추가합니다.
            wallCoordinates.Add(wallObject.transform.position);
        }

        // 좌표 리스트를 출력합니다.
        foreach (Vector3 coordinate in wallCoordinates)
        {
            //Debug.Log("Wall 좌표: " + coordinate);
        }
    }


    static bool WriteListToFile(List<string> data, string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in data)
                {
                    writer.WriteLine(line);
                }
                return true; // 성공적으로 파일에 썼음
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("파일 생성 중 오류 발생: " + e.Message);
            return false; // 파일 작성 중 오류 발생
        }
    }

    private void Draw(WallState[,] maze)
    {

        var floor = Instantiate(floorPrefab, transform);
        floor.localScale = new Vector3(width / 7.9f, 1, height / 7.9f);

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i + summonx, 0, -height / 2 + j + summony);

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }


}
