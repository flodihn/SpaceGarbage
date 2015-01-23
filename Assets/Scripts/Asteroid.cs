using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public float rotation;
	public float speed;

	void Update()
	{
		transform.Rotate(new Vector3(0, 0, rotation) * Time.deltaTime);
	}
}
