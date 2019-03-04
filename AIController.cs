using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

	public Transform player;
	Animator anim;

	float rotationSpeed = 6.0f;
	float speed = 2.0f;
	float visDist = 20.0f;
	float visAngle = 30.0f;
	float shootDist = 5.0f;

	string state = "IDLE";

	// Use this for initialization
	void Start ()
    {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction, this.transform.forward);
		
		if(direction.magnitude < visDist && angle < visAngle)
		{
			
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction), 
										Time.deltaTime * rotationSpeed);

			if(direction.magnitude > shootDist)
			{ 
				if(state != "RUNNING")
				{ 
					state = "RUNNING";	
					anim.SetTrigger("isRunning");
				}	
			}
			else
			{
				if(state != "SHOOTING")
				{ 
					state = "SHOOTING";
					anim.SetTrigger("isShooting");
				}
			}

		}
		else
		{
			if(state != "IDLE")
			{ 
				state = "IDLE";
				anim.SetTrigger("isIdle");
			}
		}

		if(state == "RUNNING")
			this.transform.Translate(0,0, Time.deltaTime * speed);

	}
}
