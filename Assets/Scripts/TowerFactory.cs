using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 4;
    [SerializeField] Tower towerObject;

    [SerializeField] Transform towerParentTransform;

    private Queue<Tower> towers = new Queue<Tower>();

    public void AddTowers(Waypoint baseWaypoint)
    {

        if (towers.Count >= towerLimit)
        {
            var oldTower = towers.Dequeue();

            oldTower.baseWaypoint.isPlaceable = true;
            baseWaypoint.isPlaceable = false;

            oldTower.baseWaypoint = baseWaypoint;
            oldTower.transform.position = new Vector3(baseWaypoint.transform.position.x, baseWaypoint.transform.position.y + 5.44f, baseWaypoint.transform.position.z + 4);

            towers.Enqueue(oldTower);
        }
        else
        {
            Vector3 positionToSpawn = new Vector3(baseWaypoint.transform.position.x, baseWaypoint.transform.position.y + 5.44f, baseWaypoint.transform.position.z + 4);
            var newTower = Instantiate(towerObject, positionToSpawn, Quaternion.identity);
            newTower.transform.parent = towerParentTransform.transform;
            newTower.baseWaypoint = baseWaypoint;
            baseWaypoint.isPlaceable = false;
            towers.Enqueue(newTower);
        }
    }
}
