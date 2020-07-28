using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    [Range(1f, 20f)] [SerializeField] float gridSize = 10f;

    TextMesh labelTextMesh;

    private void Update()
    {
        Vector3 snapPosition;

        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        gameObject.transform.position = new Vector3(snapPosition.x, 0, snapPosition.z);
        
        labelTextMesh = gameObject.GetComponentInChildren<TextMesh>();
        var cubeLabel = snapPosition.x / gridSize + "," + snapPosition.z / gridSize;
        gameObject.name = "Cube " + cubeLabel;
        labelTextMesh.text = cubeLabel;
    }
}
