using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] validDirections =
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    void Start()
    {
        LoadBlocks();
        ColorStartAndEndWaypoint();
        ExploreNeighbour();
    }

    private void ExploreNeighbour()
    {
        foreach (Vector2Int direction in validDirections)
        {
            var explorationCoordinates = startWayPoint.GetGridPos() + direction;
            if (grid.ContainsKey(explorationCoordinates))
            {
                grid[explorationCoordinates].SetTopColor(Color.cyan);

            }
        }
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
