using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Waypoint> Cubes = new List<Waypoint>();

    void Start()
    {
        foreach (var cube in Cubes)
        {
            print(cube.name);
        }
    }
}
