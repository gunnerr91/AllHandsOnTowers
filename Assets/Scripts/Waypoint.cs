﻿using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable= true;
    [SerializeField] Tower towerObject;

    const int gridSize = 11;
    public int GetGridSize() => gridSize;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("clicking: " + gameObject.name);
            if (isPlaceable)
            {
                Vector3 positionToSpawn = new Vector3(transform.position.x, transform.position.y + 5.44f, transform.position.z + 4);
                Instantiate(towerObject, positionToSpawn, Quaternion.identity);
                isPlaceable = false;
            }
        }
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
