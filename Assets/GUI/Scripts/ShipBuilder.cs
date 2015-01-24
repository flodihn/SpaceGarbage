using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SpaceGarbage;

public class ShipBuilder : MonoBehaviour {
	public Text shipInfoText;

	public void UpdateShipInfo(int shipType) {
		if(shipType == (int) ShipTypes.Fighter) {
			UpdateShipInfoFighter();
		}
	}

	public void UpdateShipInfoFighter() {
		string info;

		SpaceGarbage.Component slot1;
		SpaceGarbage.Component slot2;
		SpaceGarbage.Component slot3;

		int shipHull = 0;
		int shipShields = 0;
		ArrayList weapons = new ArrayList();

		info = "=== FIGHTER ===\n\n";

		slot1 = (SpaceGarbage.Component) Model.ReadData("fighter_slot1");
		slot2 = (SpaceGarbage.Component) Model.ReadData("fighter_slot2");
		slot3 = (SpaceGarbage.Component) Model.ReadData("fighter_slot3");

		CalcComponent(slot1, ref shipHull, ref shipShields, ref weapons);
		CalcComponent(slot2, ref shipHull, ref shipShields, ref weapons);
		CalcComponent(slot3, ref shipHull, ref shipShields, ref weapons);

		info += "Hull: " + shipHull.ToString() + "\n";
		info += "Shields: " + shipShields.ToString() + "\n";

		foreach(string weaponText in weapons) {
			info += weaponText + "\n";
		}

		shipInfoText.text = info;
	}

	public void UpdateShipInfoBomber() {
	}

	public void UpdateShipInfoCorvette() {
	}

	public void UpdateShipInfoCapitalShip() {
	}

	public void CalcComponent(SpaceGarbage.Component slot, ref int shipHull, ref int shipShields, ref ArrayList weapons) 
	{
		switch(slot) {
		case SpaceGarbage.Component.HULL:
			shipHull += 1;
			break;
		case SpaceGarbage.Component.SHIELD:
			shipShields += 1;
			break;
		case SpaceGarbage.Component.PHASER:
			weapons.Add (Model.PhaserText);
			break;
		}
	}

	public void BuildFighter() 
	{
		ArrayList components = new ArrayList();
		int shipHull = 0;
		int shipShields = 0;

		SpaceGarbage.Component slot1;
		SpaceGarbage.Component slot2;
		SpaceGarbage.Component slot3;

		slot1 = (SpaceGarbage.Component) Model.ReadData("fighter_slot1");
		slot2 = (SpaceGarbage.Component) Model.ReadData("fighter_slot2");
		slot3 = (SpaceGarbage.Component) Model.ReadData("fighter_slot3");

		if(slot1 != SpaceGarbage.Component.NULL)
			components.Add (slot1);
		if(slot2 != SpaceGarbage.Component.NULL)
			components.Add (slot2);
		if(slot3 != SpaceGarbage.Component.NULL)
			components.Add (slot3);

		if(HasComponents(components)) {
			ConsumeComponents(components);
			ShipFighter newShip = new ShipFighter();
			newShip.slot1 = slot1;
			newShip.slot1 = slot2;
			newShip.slot1 = slot3;
			Model.AddPlayerShip(newShip);
		} else {
			Debug.Log("Not enough components");
		}


	}

	bool HasComponents(ArrayList components) 
	{
		ArrayList hulls = new ArrayList();
		ArrayList shields = new ArrayList();
		ArrayList phasers = new ArrayList();
		ArrayList neutrons = new ArrayList();
		ArrayList disruptors = new ArrayList();
		ArrayList railGuns = new ArrayList();
		ArrayList heavyTurrets = new ArrayList();
		ArrayList torpedoes = new ArrayList();
		ArrayList flakks = new ArrayList();
		ArrayList antimissiles = new ArrayList();
		ArrayList scanners = new ArrayList();

		foreach(SpaceGarbage.Component comp in components) {
			switch(comp) {
			case SpaceGarbage.Component.HULL:
				hulls.Add (comp);
				break;
			case SpaceGarbage.Component.SHIELD:
				shields.Add(comp);
				break;
			case SpaceGarbage.Component.PHASER:
				phasers.Add(comp);
				break;
			case SpaceGarbage.Component.NEUTRON:
				neutrons.Add (comp);
				break;
			case SpaceGarbage.Component.DISRUPTOR:
				disruptors.Add (comp);
				break;
			case SpaceGarbage.Component.RAILGUN:
				railGuns.Add(comp);
				break;
			case SpaceGarbage.Component.HEAVYTURRET:
				heavyTurrets.Add (comp);
				break;
			case SpaceGarbage.Component.TORPEDO:
				torpedoes.Add (comp);
				break;
			case SpaceGarbage.Component.FLAKK:
				flakks.Add(comp);
				break;
			case SpaceGarbage.Component.ANTIMISSILE:
				antimissiles.Add(comp);
				break;
			case SpaceGarbage.Component.SCANNER:
				scanners.Add(comp);
				break;
			}
		}
		if(Model.ReadData("hull") < hulls.Count)
			return false;
		if(Model.ReadData("shield") < shields.Count)
			return false;
		if(Model.ReadData("phaser") < phasers.Count)
			return false;
		if(Model.ReadData("neutron") < neutrons.Count)
			return false;
		if(Model.ReadData("disruptor") < disruptors.Count)
			return false;
		if(Model.ReadData("railgun") < railGuns.Count)
			return false;
		if(Model.ReadData("heavyturret") < heavyTurrets.Count)
			return false;
		if(Model.ReadData("torpedo") < torpedoes.Count)
			return false;
		if(Model.ReadData("flakk") < flakks.Count)
			return false;
		if(Model.ReadData("antimissile") < antimissiles.Count)
			return false;
		if(Model.ReadData("scanner") < scanners.Count)
			return false;
		return true;
	}

	void ConsumeComponents(ArrayList components) 
	{
		foreach(SpaceGarbage.Component comp in components) {
			switch(comp) {
			case SpaceGarbage.Component.HULL:
				Model.AddData("hull", -1);
			break;
			case SpaceGarbage.Component.SHIELD:
				Model.AddData("shield", -1);
			break;
			case SpaceGarbage.Component.PHASER:
				Model.AddData("phaser", -1);
			break;
			case SpaceGarbage.Component.NEUTRON:
				Model.AddData("neutron", -1);
			break;
			case SpaceGarbage.Component.DISRUPTOR:
				Model.AddData("disruptor", -1);
			break;
			case SpaceGarbage.Component.RAILGUN:
				Model.AddData("railgun", -1);
			break;
			case SpaceGarbage.Component.HEAVYTURRET:
				Model.AddData("heavyturret", -1);
			break;
			case SpaceGarbage.Component.TORPEDO:
				Model.AddData("torpedo", -1);
			break;
			case SpaceGarbage.Component.FLAKK:
				Model.AddData("flakk", -1);
			break;
			case SpaceGarbage.Component.ANTIMISSILE:
				Model.AddData("antimissile", -1);
			break;
			case SpaceGarbage.Component.SCANNER:
				Model.AddData("scanner", -1);
			break;
			}
		}
	}
}
