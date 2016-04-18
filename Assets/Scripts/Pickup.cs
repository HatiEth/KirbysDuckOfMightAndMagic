using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public int HealthAdd = 1;

	public void OnTriggerEnter(Collider other)
	{
		var hc = other.gameObject.GetComponent<HealthResource>();
		if(hc != null)
		{
			hc.Heal(HealthAdd);
			Destroy(transform.parent.gameObject);
		}
	}
}
