using UnityEngine;
using System.Collections;

public class WaterHazard : MonoBehaviour {



	public void OnTriggerEnter(Collider other)
	{
		KillUnit(other.gameObject);
	}


	void KillUnit(GameObject go)
	{
		var hc = go.GetComponent<HealthResource>();
		if(hc)
		{
			hc.Take(hc.Current);
		}
	}
}
