using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour {

	public float LifetimeS = 0f;

	// Use this for initialization
	void Start () {
		if(LifetimeS > 0f)
		{
			StartCoroutine(HandleLifetime());
		}
	
	}
	
	IEnumerator HandleLifetime () {
		yield return new WaitForSeconds(LifetimeS);
		Destroy(gameObject);
	}
}
