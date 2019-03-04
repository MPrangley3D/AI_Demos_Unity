using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public Transform goal;
    public float speed = 1.0f;

	void Start ()
    {
		
	}
	
	void LateUpdate () 
	{
        this.transform.LookAt(goal.position);
        Vector3 direction = goal.position - this.transform.position;
        if (direction.magnitude > 0.1f)
        {
            
            Debug.DrawRay(this.transform.position, direction, Color.red);
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
