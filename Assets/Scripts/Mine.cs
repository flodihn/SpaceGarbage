using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public float proximityRadius;
	public float blastRadius;
	public Transform playerTransform;
	public float detonationTime;
	public GameObject particles;

	private bool isLive;
	private float detonationTimer;
	private SpriteRenderer spriteRenderer;

	void Start () 
	{
		playerTransform = GameObject.Find ("player").transform;
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update ()
	{
		DetectPlayer ();

		if(!isLive)
			return;
		Detonate ();
	}

	void DetectPlayer()
	{
		float distance = Vector3.Distance(playerTransform.position,transform.position);
		if(distance <= proximityRadius)
			isLive = true;
	}

	void Detonate()
	{
		detonationTimer += Time.deltaTime;

		spriteRenderer.color = new Color (1, 0, 0,  1);

		if(Timer.TimeExceeded(detonationTimer, detonationTime))
		{
			Destroy(gameObject);
			Instantiate(particles,transform.position,Quaternion.identity);
		}
	}
}
