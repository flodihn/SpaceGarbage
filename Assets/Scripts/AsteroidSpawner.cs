using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {

	public Asteroid asteroidPrefab;
	public float cooldown;
	private Transform playerTransform;

	private Vector3 topLeft;
	private Vector3 topRight;
	private Vector3 bottomLeft;
	private Vector3 bottomRight;
	private Vector3 directionFromCenter;
	private float timer;

	void Start () 
	{
		playerTransform = transform.parent;
		UpdateBounds ();
	}

	void Update () 
	{
		UpdateBounds ();
		timer += Time.deltaTime;

		if(Timer.TimeExceeded(ref timer,cooldown))
			SpawnAsteroid();
	}
	
	void UpdateBounds ()
	{
		topLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 10));
		topRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 10));
		bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 10));
		bottomRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 10));

		directionFromCenter = topLeft - playerTransform.position;
	}

	void SpawnAsteroid()
	{
		Vector3 randomVector = new Vector3 (Random.Range (-10, 10),
		                                    Random.Range (-10, 10),
		                                    0);
		Debug.Log (randomVector.normalized);
		//Asteroid asteroid = Instantiate (asteroidPrefab,playerTransform.position + randomVector.normalized * 10,Quaternion.identity) as Asteroid;
		//asteroid.direction = playerTransform.position - randomVector;
	}
}
