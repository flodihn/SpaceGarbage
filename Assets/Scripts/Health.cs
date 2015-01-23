using System.Collections;

public class Health {

	private float hitPoints;
	private bool isDead;

	public Health(float hitPoints)
	{
		this.hitPoints = hitPoints;
	}

	public void ChangeHitPoints(float amount)
	{
		hitPoints += amount;

		if(hitPoints <= 0)
			isDead = true;
	}

	public bool IsDead
	{
		get{ return isDead; }
	}
}
