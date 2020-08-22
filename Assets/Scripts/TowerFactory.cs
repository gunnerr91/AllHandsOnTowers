using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 4;
    [SerializeField] Tower towerObject;

    public void AddTowers(Waypoint baseWaypoint)
    {

        Vector3 positionToSpawn = new Vector3(baseWaypoint.transform.position.x, baseWaypoint.transform.position.y + 5.44f, baseWaypoint.transform.position.z + 4);
        Instantiate(towerObject, positionToSpawn, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
    }
}
