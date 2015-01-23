using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Health playerHealth = new Health(100);
	private Vector3 targetPosition;
	private Vector3 direction;

	void Start () 
	{
	
	}

	void Update () 
	{
		if(playerHealth.IsDead)
			return;

		Movement ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject go = col.gameObject;

		if(go.layer != LayerMask.NameToLayer("Asteroid"))
			return;

		playerHealth.ChangeHitPoints(-100);
	}

	private void Movement()
	{
		Vector3 mousePos;
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * 10);

		if(Input.GetMouseButtonDown(0))
		{
			targetPosition = mousePos;

			direction = mousePos - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

		if(Vector3.Distance(transform.position,targetPosition) > 0.5f)
			transform.position += direction.normalized * Time.deltaTime;
	}
}
