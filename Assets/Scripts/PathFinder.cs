using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queueOfWaypoints = new Queue<Waypoint>();
    bool isRunning = true;
    Vector2Int[] validDirections =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlocks();
        ColorStartAndEndWaypoint();
        PathFind();
    }

    private void PathFind()
    {
        queueOfWaypoints.Enqueue(startWayPoint);

        while(queueOfWaypoints.Count > 0 && isRunning)
        {
            var searchCenter = queueOfWaypoints.Dequeue();
            print("Exploring from: " + searchCenter);
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExplored = true;
        }

        print("Finished pathfinding");
    }

    private void HaltIfEndFound(Waypoint currentInQueue)
    {
        if (currentInQueue == endWayPoint) 
        {
            print("searching from end node");
            isRunning = false;
        }

    }

    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunning) return;
        foreach (Vector2Int direction in validDirections)
        {
            var neighbourCoordinates = from.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbour(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];

        if (neighbour.isExplored) return;

        neighbour.SetTopColor(Color.cyan);
        queueOfWaypoints.Enqueue(neighbour);
        print("Queuing " + neighbour);
    }

    private void ColorStartAndEndWaypoint()
    {
        startWayPoint.SetTopColor(Color.white);
        endWayPoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (var waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                print(waypoint.name + " is overlapping");
            }
            else
            {
                grid.Add(gridPos, waypoint);
                waypoint.SetTopColor(Color.gray);
            }
        }
    }
}
