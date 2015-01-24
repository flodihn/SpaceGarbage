using UnityEngine;
using System.Collections;
using SpaceGarbage;
using UnityEngine.UI;

public class ShipList : MonoBehaviour {
	public enum ListMode {
		PlayerShips,
		EnemyShips
	};
	public ListMode mode;

	void Start() {
		Model.AddListener (gameObject);
	}

	void OnEnable() { 
		if(mode == ListMode.PlayerShips)
			AddPlayerShipCallback();
		else if(mode == ListMode.EnemyShips)
			AddEnemyShipCallback();
	}

	public void AddEnemyShipCallback() {
		ArrayList ships;
		ships = Model.GetEnemyShips();
		UpdateList (ships);
	}

	public void AddPlayerShipCallback() {
		ArrayList ships;
		ships = Model.GetPlayerShips();
		UpdateList (ships);
	}

	public void UpdateList(ArrayList ships) {
		Text text = GetComponent<Text> ();

		ArrayList fighters = new ArrayList();
		ArrayList bombers = new ArrayList ();
		ArrayList corvettes = new ArrayList ();
		ArrayList capitalShips = new ArrayList ();
		string prepend;

		if (mode == ListMode.PlayerShips) {
			prepend = "You have ";
		} else {
			prepend = "The enemy has ";
		}

		text.text = prepend + "a total of " + ships.Count.ToString () + " ships.\n\n";


		foreach (Ship ship in ships) {
			if(ship.shipType == ShipTypes.Fighter) {
				fighters.Add (ship);
			} else if(ship.shipType == ShipTypes.Bomber) {
				bombers.Add (ship);
			} else if(ship.shipType == ShipTypes.Corvette) {
				corvettes.Add (ship);
			} else if(ship.shipType == ShipTypes.CapitalShip) {
				capitalShips.Add (ship);
			}
		}

		if(fighters.Count > 0)
			text.text += prepend + fighters.Count.ToString () + " fighters.\n";
		if(bombers.Count > 0)
			text.text += prepend + bombers.Count.ToString () + " bombers.\n";
		if(corvettes.Count > 0)
			text.text += prepend + corvettes.Count.ToString () + " corvettes.\n";
		if(capitalShips.Count > 0)
			text.text += prepend + capitalShips.Count.ToString () + " capital ships.\n";
	}
}
