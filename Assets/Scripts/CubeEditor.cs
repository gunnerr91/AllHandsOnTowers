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
        var gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y);

        //gameObject.transform.position = new Vector3(gridPos.x, 0, gridPos.z);
    }

    private void UpdateLabel()
    {
        var labelTextMesh = gameObject.GetComponentInChildren<TextMesh>();
        var gridSize = waypoint.GetGridSize();
        var cubeLabel = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
        gameObject.name = "Grid " + cubeLabel;
        labelTextMesh.text = cubeLabel;
    }
}
