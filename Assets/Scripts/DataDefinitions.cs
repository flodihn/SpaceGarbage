using UnityEngine;
using System.Collections;

public class StringValue : System.Attribute
{
	private string _value;
	
	public StringValue(string value)
	{
		_value = value;
	}
	
	public string Value
	{
		get { return _value; }
	}
	
}

namespace SpaceGarbage {

	public enum ShipTypes {
		Fighter,
		Bomber,
		Corvette,
		CapitalShip
	}


	public enum Component
	{
		[StringValue("hull")]
		HULL,
		[StringValue("shield")]
		SHIELD,
		[StringValue("phaser")]
		PHASER,
		[StringValue("neutron")]
		NEUTRON,
		[StringValue("disruptor")]
		Disruptor,
		[StringValue("railgun")]
		RAILGUN,
		[StringValue("heavyturret")]
		HEAVYTURRET,
		[StringValue("torpedo")]
		TORPEDO,
		[StringValue("flakk")]
		FLAKK,
		[StringValue("antimissile")]
		ANTIMISSILE,
		[StringValue("scanner")]
		SCANNER
	}


	public class Ship {

		public ShipTypes shipType;

		public Ship() {
			shipType = ShipTypes.Fighter;

		}
	}
}


