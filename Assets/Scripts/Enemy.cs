using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movementPeriod = 1f;
    [SerializeField] ParticleSystem selfDestructPrefab;
    void Start()
    {
        transform.position = new Vector3(transform.position.y, transform.position.y + 10, transform.position.y);
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
            yield return new WaitForSeconds(movementPeriod);
        }
        print("Ending patrol");
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(selfDestructPrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
 