﻿using UnityEngine;
using System.Collections;

public class Dock : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag == "Player") {
			Application.LoadLevel("ShipBuilderScene");
		}
	}
}
