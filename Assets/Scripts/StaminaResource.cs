using UnityEngine;
using System.Collections;

public class StaminaResource : MonoBehaviour {

	public float Max;
	public float Current { get; private set; }

	public float RegenPerSecond = 1f;

	// Use this for initialization
	void Start () {
		Current = Max;
	}
	
	// Update is called once per frame
	void Update () {
		Current = Mathf.Min(Current + RegenPerSecond*Time.deltaTime, Max);
	}

	public void Use(float stamina)
	{
		Current -= stamina;
		Current = Mathf.Max(Current, 0);
	}
}
