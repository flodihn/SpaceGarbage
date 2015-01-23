using UnityEngine;
using System.Collections;

public static class Timer 
{
	public static bool TimeExceeded(ref float time, float timeLimit)
	{
		if(time >= timeLimit)
		{
			time = 0;
			return true;
		}

		else
			return false;
	}

	public static bool TimeExceeded(float time, float timeLimit)
	{
		if(time >= timeLimit)
			return true;
		
		else
			return false;
	}
}
