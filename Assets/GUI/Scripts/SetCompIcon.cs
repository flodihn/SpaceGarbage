using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetCompIcon : MonoBehaviour {

	public string key;

	void Update () {
		GetComponent<Text> ().text = "x " + Model.ReadData (key).ToString ();
	}
}
