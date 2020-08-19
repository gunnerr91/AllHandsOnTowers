﻿using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;

    const int gridSize = 11;
    public int GetGridSize() => gridSize;

    private void OnMouseOver()
    {
        print("hovering over: " + gameObject.name);
    }

    public Vector2Int GetGridPos() => new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRendered = transform.Find("X_Top").GetComponent<MeshRenderer>();
        topMeshRendered.material.color = color;
    }
}
