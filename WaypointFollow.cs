using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    //public GameObject[] waypoints;
    public UnityStandardAssets.Utility.WaypointCircuit circuit;
    int currentWaypoint = 0;

    public float speed = 5.0f;
    public float accuracy = 1.0f;
    public float rotSpeed = 4.0f;

    private void Start()
    {
        //waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    private void LateUpdate()
    {
        if (circuit.Waypoints.Length == 0) return;

        Vector3 lookAtGoal = new Vector3(circuit.Waypoints[currentWaypoint].transform.position.x,
                                                    this.transform.position.y,
                                                    circuit.Waypoints[currentWaypoint].transform.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                Quaternion.LookRotation(direction),
                                                Time.deltaTime * rotSpeed);

        if(direction.magnitude < accuracy)
        {
            currentWaypoint++;
            if(currentWaypoint >= circuit.Waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
