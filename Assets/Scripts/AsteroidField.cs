using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidField : MonoBehaviour {
	
	public Asteroid asteroidPrefab;
	public float resolution;
	public float radius;

	public float rotationSpeed;
	private Asteroid asteroidInstance;
	private List<Asteroid> asteroids = new List<Asteroid>();

	void Start () 
	{
		CalculateRing (radius, transform.position);
	}
	
	void Update () 
	{
		foreach(Asteroid asteroid in asteroids)
			asteroid.transform.RotateAround(transform.position,
			                                Vector3.forward,
			                                rotationSpeed * Time.deltaTime);
	}

	void CalculateRing(float radius, Vector3 center)
	{
		float factor = 360 / resolution;

		for(int i = 0;i < resolution;i++)
		{
			float radian = (factor * i) * Mathf.Deg2Rad;
			float x = center.x + radius * (Mathf.Cos (radian) * Mathf.Rad2Deg);
			float y = center.y + radius * (Mathf.Sin (radian) * Mathf.Rad2Deg);
			Debug.Log(i * factor);

			Vector3 position = new Vector3(x , y, 0);
			Debug.DrawLine(center, position, Color.red,20);
			asteroidInstance = Instantiate(asteroidPrefab, position, Quaternion.identity) as Asteroid;
			asteroids.Add(asteroidInstance);
		}
	}
}
