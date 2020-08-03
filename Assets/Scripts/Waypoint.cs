using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 11;

    public int GetGridSize() => gridSize;

    public Vector2Int GetGridPos() => new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
        Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );

    public void SetTopColor(Color color)
    {
        print(transform.Find("X_Top"));
        MeshRenderer topMeshRendered = transform.Find("X_Top").GetComponent<MeshRenderer>();
        topMeshRendered.material.color = color;
    }
}
