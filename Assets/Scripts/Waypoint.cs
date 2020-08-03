using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 11;
    void Start()
    {
        
    }

    public int GetGridSize() => gridSize;

    public Vector2 GetGridPos() => new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
        Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );

    // Update is called once per frame
    void Update()
    {
        
    }
}
