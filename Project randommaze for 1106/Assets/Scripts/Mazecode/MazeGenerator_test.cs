using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Flags]
public enum Wallstate_test
{
    // 0000 -> no walls
    // 1111 -> left, right, up, down
    LEFT = 1, // 0001
    RIGHT = 2, // 0010
    UP = 4, // 0100 #4
    DOWN = 8, // 1000 #8

    VISITED = 128, // 1000 0000
}

public struct Position_test
{
    public int X;
    public int Y;
}

public struct Neighbour_test
{
    public Position_test Position_test;
    public Wallstate_test SharedWall;
}

public static class MazeGenerator_test
{

    private static Wallstate_test GetOppositeWall(Wallstate_test wall)
    {
        switch(wall)
        {
            case Wallstate_test.RIGHT: return Wallstate_test.LEFT;
            case Wallstate_test.LEFT: return Wallstate_test.RIGHT;
            case Wallstate_test.UP: return Wallstate_test.DOWN;
            case Wallstate_test.DOWN: return Wallstate_test.UP;
            default: return Wallstate_test.LEFT;
        }
    }

    private static Wallstate_test[,] ApplyRecursiveBacktracker(Wallstate_test[,] maze, int width, int height)
    {
        var rng = new System.Random(/*seed*/);
        var Position_testStack = new Stack<Position_test>();
        var Position_test = new Position_test { X = rng.Next(0, width), Y = rng.Next(0, height)};

        maze[Position_test.X, Position_test.Y] |= Wallstate_test.VISITED;
        Position_testStack.Push(Position_test);

        while (Position_testStack.Count > 0)
        {
            var current = Position_testStack.Pop();
            var Neighbour_tests = GetUnvisitedNeighbour_test(current, maze, width, height);

            if(Neighbour_tests.Count > 0)
            {
                Position_testStack.Push(current);

                var randIndex = rng.Next(0, Neighbour_tests.Count);
                var randomNeighbour_test = Neighbour_tests[randIndex];

                var nPosition_test = randomNeighbour_test.Position_test;
                maze[current.X, current.Y] &= ~randomNeighbour_test.SharedWall;
                maze[nPosition_test.X, nPosition_test.Y] &= ~GetOppositeWall(randomNeighbour_test.SharedWall);

                maze[nPosition_test.X, nPosition_test.Y] |= Wallstate_test.VISITED;

                Position_testStack.Push(nPosition_test);
            }
        }

        return maze;
    }


    private static List<Neighbour_test> GetUnvisitedNeighbour_test(Position_test p, Wallstate_test[,] maze, int width, int height)
    {
        var list = new List<Neighbour_test>();

        if(p.X > 0) // left
        {
            if(!maze[p.X - 1, p.Y].HasFlag(Wallstate_test.VISITED))
            {
                list.Add(new Neighbour_test
                        {
                            Position_test = new Position_test
                            {
                                X = p.X - 1,
                                Y = p.Y
                            },
                            SharedWall = Wallstate_test.LEFT
                        });
            }
        }

        if(p.Y > 0) // down
        {
            if(!maze[p.X, p.Y - 1].HasFlag(Wallstate_test.VISITED))
            {
                list.Add(new Neighbour_test
                        {
                            Position_test = new Position_test
                            {
                                X = p.X,
                                Y = p.Y - 1
                            },
                            SharedWall = Wallstate_test.DOWN
                        });
            }
        }

        if(p.Y < height - 1) // up
        {
            if(!maze[p.X, p.Y + 1].HasFlag(Wallstate_test.VISITED))
            {
                list.Add(new Neighbour_test
                        {
                            Position_test = new Position_test
                            {
                                X = p.X,
                                Y = p.Y + 1
                            },
                            SharedWall = Wallstate_test.UP
                        });
            }
        }

        if(p.X < width - 1) // right
        {
            if(!maze[p.X + 1, p.Y].HasFlag(Wallstate_test.VISITED))
            {
                list.Add(new Neighbour_test
                        {
                            Position_test = new Position_test
                            {
                                X = p.X + 1,
                                Y = p.Y
                            },
                            SharedWall = Wallstate_test.RIGHT
                        });
            }
        }

        return list;
    }
    public static Wallstate_test[,] Generate(int width, int height)
    {
        Wallstate_test[,] maze = new Wallstate_test[width, height];
        Wallstate_test initial = Wallstate_test.RIGHT | Wallstate_test.LEFT | Wallstate_test.UP | Wallstate_test.DOWN;
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                maze[i, j] = initial; // 1111

            }
        }

        return ApplyRecursiveBacktracker(maze, width, height);
    }
}