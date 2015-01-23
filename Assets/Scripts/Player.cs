using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float maxSpeed;

	void Update () {
		RotateTowardsDirection();

	}

	void FixedUpdate() {
		AccelerateShip();
	}

	void RotateTowardsDirection()
	{
		Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);        //Mouse position
		Vector3 objpos = Camera.main.WorldToViewportPoint (transform.position);        //Object position on screen
		Vector2 relobjpos = new Vector2(objpos.x - 0.5f,objpos.y - 0.5f);            //Set coordinates relative to object
		Vector2 relmousepos = new Vector2 (mouse.x - 0.5f,mouse.y - 0.5f) - relobjpos;
		float angle = Vector2.Angle (Vector2.up, relmousepos);    //Angle calculation
		if (relmousepos.x > 0)
			angle = 360-angle;
		Quaternion quat = Quaternion.identity;
		quat.eulerAngles = new Vector3(0,0,angle); //Changing angle
		transform.rotation = quat;
	}
	
	void AccelerateShip()
	{
		if(!Input.GetMouseButton(0))
			return;

		if(rigidbody2D.velocity.magnitude > maxSpeed)
			return;

		rigidbody2D.AddRelativeForce(new Vector3(0, 1, 0) * 1.0f);
	}
}
