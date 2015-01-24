using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform playerTransform;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 targetPos = new Vector3 (playerTransform.position.x, playerTransform.position.y, -10);
		//transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime * 2);
		transform.position = targetPos;
	}
}
