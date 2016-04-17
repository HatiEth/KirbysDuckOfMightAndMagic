using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class HealthResource : MonoBehaviour {

	public delegate void OnDeath ();

	public OnDeath DeathCallback;

	public bool Invulnerable = false;
	public int Maximum;
	public int Current { get; private set; }
	public bool Indestructible = false;

	// Use this for initialization
	void Start () {
		Current = Maximum;
	}

	public void Heal(int health)
	{
		Assert.IsTrue(health >= 0);

		Current = Mathf.Min(Current + health, Maximum);
	}

	public void Take(int health)
	{
		if (Invulnerable) return;
		Current = Mathf.Max(Current - health, 0);

		if(Current <= 0)
		{
			if(DeathCallback != null)
			{
				DeathCallback();
			}

			if(!Indestructible)
			{
				Destroy(gameObject);
			}
		}
	}
	
}
