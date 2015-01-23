using UnityEngine;
using System.Collections;

public class ShipComponent : MonoBehaviour {
	public string componentType;
	public int amount = 1;

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "Player") {
			Model.AddData (componentType, amount);
			Destroy(gameObject);
		}
	}
}
