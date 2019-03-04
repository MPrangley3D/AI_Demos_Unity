using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFacing: MonoBehaviour
{

    public Transform goal;
    public float speed = 0.5f;
    public float accuracy = 1.0f;
    public float rotSpeed = 3.5f;

    void Start()
    {

    }

    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
        Debug.DrawRay(this.transform.position, direction, Color.red);
    }
}
