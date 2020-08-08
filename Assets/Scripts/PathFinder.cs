using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queueOfWaypoints = new Queue<Waypoint>();
    Waypoint currentSearchCenter;
    List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEndWaypoint();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    bool isRunning = true;
    Vector2Int[] validDirections =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    private void CreatePath()
    {
        path.Add(endWayPoint);

        Waypoint previous = endWayPoint.exploredFrom;
        while (previous != startWayPoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(startWayPoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queueOfWaypoints.Enqueue(startWayPoint);

        while (queueOfWaypoints.Count > 0 && isRunning)
        {
            currentSearchCenter = queueOfWaypoints.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            currentSearchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if (currentSearchCenter == endWayPoint)
        {
            isRunning = false;
        }

    }

    private void ExploreNeighbours()
    {
        if (!isRunning) return;
        foreach (Vector2Int direction in validDirections)
        {
            var neighbourCoordinates = currentSearchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbour(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];

        if (neighbour.isExplored || queueOfWaypoints.Contains(neighbour)) return;

        queueOfWaypoints.Enqueue(neighbour);
        neighbour.exploredFrom = currentSearchCenter;
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
