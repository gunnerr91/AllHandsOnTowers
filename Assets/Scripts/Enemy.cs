using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Waypoint> Path = new List<Waypoint>();

    void Start()
    {
        //StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("Starting patrol...");
        foreach (var waypoint in Path)
        {
            transform.position = new Vector3(waypoint.transform.position.x, transform.position.y, waypoint.transform.position.z + 5);
            print("Visiting block: " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol");
    }
}
