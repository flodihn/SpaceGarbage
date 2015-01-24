using UnityEngine;
using System.Collections;

public class SceneRandomizer : MonoBehaviour {
	public int numJunk;

	public int minX;
	public int maxX;
	public int minY;
	public int maxY;

	public int minCompX;
	public int maxCompX;
	public int minCompY;
	public int maxCompY;


	public GameObject[] junkParts;
	public GameObject[] compParts;
	public int[] numCompParts;

	// Use this for initialization
	void Start () {
		RandomizeScene();
	}

	void RandomizeScene() {
		RandomizeJunk();
		RandomizeComponents();
	}

	void RandomizeJunk() {
		GameObject junkObj;
		
		int i;
		for(i = 0; i < numJunk; i++) {
			CreateSceneObject(junkParts[Random.Range(0, junkParts.Length)], false);
		}
	}

	void RandomizeComponents()
	{
		int i, j;
		for(i = 0; i < numCompParts.Length; i++) {
			int numMaxComponents = numCompParts[i];
			for(j = 0; j < numMaxComponents; j++) {
				CreateSceneObject(compParts[Random.Range(0, compParts.Length)], true);
			}
		}
	}

	GameObject CreateSceneObject(GameObject prefab, bool isObjComponent) {
		Vector3 newPos;


		if(isObjComponent) {
			newPos = new Vector3(
				Random.Range(minCompX, maxCompX),
				Random.Range(minCompY, maxCompY),
				0);
		} else {
			newPos = new Vector3(
				Random.Range(minX, maxX),
				Random.Range(minY, maxY),
				0);
		}

		if(Vector3.Distance(Vector3.zero, newPos) < 7.5f)
			return null;

		GameObject ob = (GameObject) Instantiate(
			prefab,
			newPos,
			Quaternion.Euler(new Vector3(
				0,
				0,
				Random.Range(0, 360)
			)));
		return ob;
	}
}
