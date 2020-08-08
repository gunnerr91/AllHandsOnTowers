using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (var waypoint in path)
        {
            transform.position = new Vector3(waypoint.transform.position.x, transform.position.y, waypoint.transform.position.z + 5);
            print("Visiting block: " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol");
    }
}
