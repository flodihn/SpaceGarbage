using UnityEngine;
using System.Collections;

using SpaceGarbage;

public class LoadModelWithSampleData : MonoBehaviour {
	void Start() {
		LoadSampleData ();
	}

	public void LoadSampleData() {
		Model.AddData ("hull", 32);
		Model.AddData ("shield", 32);
		Model.AddData ("phaser", 32);
		Model.AddData ("neutron", 32);
		Model.AddData ("disruptor", 32);
		Model.AddData ("railgun", 32);
		Model.AddData ("heavyturret", 32);
		Model.AddData ("torpedo", 32);
		Model.AddData ("flakk", 32);
		Model.AddData ("antimissile", 32);
		Model.AddData ("scanner", 32);

		AddEnemyFighter (10);
	}

	public void AddPlayerPlayeFighter() {
		Ship ship = new Ship ();
		ship.shipType = ShipTypes.Fighter;
		Model.AddPlayerShip (ship);
	}

	public void AddPlayerPlayeBomber() {
		Ship ship = new Ship ();
		ship.shipType = ShipTypes.Bomber;
		Model.AddPlayerShip (ship);
	}

	public void AddPlayerPlayeCorvette() {
		Ship ship = new Ship ();
		ship.shipType = ShipTypes.Corvette;
		Model.AddPlayerShip (ship);
	}

	public void AddPlayerPlayeCapitalShip() {
		Ship ship = new Ship ();
		ship.shipType = ShipTypes.CapitalShip;
		Model.AddPlayerShip (ship);
	}

	// Enemies
	public void AddEnemyFighter(int num) {
		int i;
		for(i = 0; i < num; i++) {
			Ship ship = new Ship ();
			ship.shipType = ShipTypes.Fighter;
			Model.AddEnemyShip (ship);
		}
	}
	
	public void AddEnemyBomber() {
		Ship ship = new Ship ();
		ship.shipType = ShipTypes.Bomber;
		Model.AddEnemyShip (ship);
	}
	
	public void AddEnemyCorvette() {
		Ship ship = new Ship ();
		ship.shipType = ShipTypes.Corvette;
		Model.AddEnemyShip (ship);
	}
	
	public void AddEnemyCapitalShip() {
		Ship ship = new Ship ();
		ship.shipType = ShipTypes.CapitalShip;
		Model.AddEnemyShip (ship);
	}
}
