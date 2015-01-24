using UnityEngine;
using System.Collections;
using SpaceGarbage;

public class BattleEngine : MonoBehaviour {
	public enum BattleEngineEvents {
		PLAYER_FIGHER_ATTACK,
		PLAYER_BOMBER_ATTACK,
		PLAYER_CORVETTE_ATTACK,
		PLAYER_CAPITAL_SHIP_ATTACK,
		ENEMY_FIGHTER_ATTACK,
		ENEMY_BOMBER_ATTACK,
		ENEMY_CORVETTE_ATTACK,
		ENEMY_CAPITAL_SHIP_ATTACK
	};

	public ArrayList playerShips;
	public ArrayList playerFighters = new ArrayList ();
	public ArrayList playerBombers = new ArrayList ();
	public ArrayList playerCorvettes = new ArrayList ();
	public ArrayList playerCapitalShips = new ArrayList ();

	public ArrayList enemyShips;
	public ArrayList enemyFighters = new ArrayList ();
	public ArrayList enemyBombers = new ArrayList ();
	public ArrayList enemyCorvettes = new ArrayList ();
	public ArrayList enemyCapitalShips = new ArrayList ();

	public float eventFrequency;

	private float timeSinceLastEvent;
	private bool runBattle = false;

	public void StartBattle () {
		runBattle = true;

		/*
		playerShips = Model.GetPlayerShips ();


		foreach (Ship ship in playerShips) {
			if(ship.shipType == ShipTypes.Fighter) {
				playerFighters.Add (ship);
			} else if(ship.shipType == ShipTypes.Bomber) {
				playerBombers.Add (ship);
			} else if(ship.shipType == ShipTypes.Corvette) {
				playerCorvettes.Add (ship);
			} else if(ship.shipType == ShipTypes.CapitalShip) {
				playerCapitalShips.Add (ship);
			}
		}

		enemyShips = Model.GetEnemyShips ();
		foreach (Ship ship in enemyShips) {
			if(ship.shipType == ShipTypes.Fighter) {
				enemyFighters.Add (ship);
			} else if(ship.shipType == ShipTypes.Bomber) {
				enemyBombers.Add (ship);
			} else if(ship.shipType == ShipTypes.Corvette) {
				enemyCorvettes.Add (ship);
			} else if(ship.shipType == ShipTypes.CapitalShip) {
				enemyCapitalShips.Add (ship);
			}
		}
		*/
	}

	void Update() {
		/*
		if (!runBattle)
			return;
		timeSinceLastEvent += Time.deltaTime;

		if (timeSinceLastEvent < eventFrequency)
						return;

		PlayerTurn();
		EnemyTurn();

		if(HasBattleEnded()) {
			if(DidPlayerWin ()) {
				TriggerSuccess();
			} else {
				TriggerFailure();
			}
		}
		timeSinceLastEvent = 0;
		*/
	}

	void PlayerTurn() {
	}

	void EnemyTurn() {
	}

	bool HasBattleEnded() {
		return false;
	}

	bool DidPlayerWin() {
		return false;
	}
	
	void TriggerSuccess() {
	}

	void TriggerFailure() {
	}

	public void ReturnToShip() {
		Application.LoadLevel("GarbageSpace");
	}
	
}
