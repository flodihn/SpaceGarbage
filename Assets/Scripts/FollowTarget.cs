using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {
	public float yDistance;
	public GameObject target;

	void Update () {
		transform.position = new Vector3(
			target.transform.position.x,
			yDistance,
			target.transform.position.z);
	}
}
