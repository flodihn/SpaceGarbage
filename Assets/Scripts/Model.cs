using UnityEngine;
using System.Collections;
using System.Collections.Generic;


using SpaceGarbage;

public static class Model {
	public static Dictionary <string, int> data = new Dictionary<string, int>();
	public static ArrayList enemyShips = new ArrayList();
	public static ArrayList playerShips = new ArrayList();
	
	public static ArrayList listeners = new ArrayList();
	
	public static void AddListener(GameObject listener)
	{
		listeners.Add (listener);
	}
	
	/// <summary>
	/// Sets data new or existing
	/// </summary>
	/// <param name="key">Key.</param>
	/// <param name="value">Value.</param>
	/// <param name="overwrite">If set to <c>true</c> overwrite.</param>
	/// 
	public static void SetData(string key, int value)
	{
		SetData (key, value, true);
	}
	public static void SetData(string key, int value, bool overwrite)
	{
		if(!overwrite && data.ContainsKey(key))
			return;
		
		data [key] = value;
	}
	
	/// <summary>
	/// Adds the value sent to the existing value at the key
	/// </summary>
	/// <param name="key">Key.</param>
	/// <param name="value">Value.</param>
	public static void AddData(string key, int value)
	{
		if(data.ContainsKey(key))
			data[key] += value;
		else
			data [key] = value;
	}
	
	/// <summary>
	/// Reads the data from key
	/// </summary>
	/// <returns>The data.</returns>
	/// <param name="key">Key.</param>
	public static int ReadData(string key)
	{
		if(data.ContainsKey(key))
			return data[key];
		
		return 0;
	}
	
	public static void AddPlayerShip(Ship ship) {
		playerShips.Add (ship);
		foreach (GameObject listener in listeners) {
			if(listener.activeSelf)
				listener.SendMessage("AddPlayerShipCallback");
		}
	}
	
	public static void AddEnemyShip(Ship ship) {
		enemyShips.Add (ship);
		foreach (GameObject listener in listeners) {
			if(listener.activeSelf)
				listener.SendMessage("AddEnemyShipCallback");
		}
	}
	
	public static ArrayList GetPlayerShips() {
		return playerShips;
	}
	
	public static ArrayList GetEnemyShips() {
		return enemyShips;
	}
}