using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class HealthResource : MonoBehaviour {

	public delegate void OnDeath ();

	public OnDeath DeathCallback;

	public bool Invulnerable = false;

	private int InvulnerableFrames = 0;

	public int Maximum;
	public int Current { get; private set; }
	public bool Indestructible = false;
	private bool hasDied = false;
	public Animator m_animThis;
	// Use this for initialization
	void Start () {
		Current = Maximum;
	}

	void FixedUpdate()
	{
		if(InvulnerableFrames > 0)
		{
			InvulnerableFrames = Mathf.Max(InvulnerableFrames - 1, 0);
		}
	}

	public void Heal(int health)
	{
		Assert.IsTrue(health >= 0);

		Current = Mathf.Min(Current + health, Maximum);
	}

	public void Take(int health)
	{
		if (Invulnerable && InvulnerableFrames > 0) return;
		Current = Mathf.Max(Current - health, 0);
		InvulnerableFrames = 32;

		if(Current <= 0)
		{
			if(DeathCallback != null)
			{
				DeathCallback();
			}

			if(!Indestructible)
			{
				StartCoroutine (DieAfterAnim ());
			}
		}
	}

	private IEnumerator DieAfterAnim()
	{
		if (m_animThis)
		{
			if (!hasDied)
			{
				hasDied = true;
				Debug.Log ("Die");
				m_animThis.SetTrigger ("tDie");
				yield return new WaitForSeconds (2.0f);
				GameObject.Destroy (this.gameObject);	
			}

		} 
		else
		{
			GameObject.Destroy (this.gameObject);

		}
	}
}
