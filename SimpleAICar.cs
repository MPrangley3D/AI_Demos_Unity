using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAICar : MonoBehaviour {

	public Transform goal;
	public Text readout;
    public float acceleration = 5f;
    public float deceleration = 3f;
	public float minSpeed = 0.0f;
    public float maxSpeed = 60.0f;
    public float rotSpeed = 10.0f;
    public float brakeAngle = 20.0f;
    private float speed = 0;
    private float initialY = 0;

	// Use this for initialization
	void Start () {
        initialY = this.transform.position.y;
        maxSpeed = maxSpeed + Random.Range(0f, 20f);
        acceleration = acceleration * Random.Range(0.75f, 1.25f);
        deceleration = deceleration * Random.Range(0.9f, 1.5f);
        rotSpeed = rotSpeed * Random.Range(0.5f, 1.5f);
        brakeAngle = brakeAngle * Random.Range(0.75f, 1.5f);
    }
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 lookAtGoal = new Vector3(goal.position.x, 
										this.transform.position.y, 
										goal.position.z);
		Vector3 direction = lookAtGoal - this.transform.position;

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
												Quaternion.LookRotation(direction), 
												Time.deltaTime*rotSpeed);
      

        if(Vector3.Angle(goal.forward,this.transform.forward) > brakeAngle && speed > 10)
        {
            speed = Mathf.Clamp(speed - (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }

        if (this.transform.position.y != initialY)
        {
            this.transform.position = new Vector3(this.transform.position.x, initialY, this.transform.position.z);
        }
        
        this.transform.Translate(0,0,speed);
		AnalogueSpeedConverter.ShowSpeed(speed, minSpeed, maxSpeed);
        if(readout)
        {
            readout.text = "" + (int)speed;
        }
    }
}
