using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        SnapToGrid();

        UpdateLabel();
    }


    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        var gridPos = waypoint.GetGridPos() * gridSize;
        transform.position = new Vector3(gridPos.x, 0f, gridPos.y);
    }

    private void UpdateLabel()
    {
        var labelTextMesh = gameObject.GetComponentInChildren<TextMesh>();
        var cubeLabel = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        gameObject.name = "Grid " + cubeLabel;
        labelTextMesh.text = cubeLabel;
    }
}
