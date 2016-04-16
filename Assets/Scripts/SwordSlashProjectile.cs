using UnityEngine;
using System.Collections;

public class SwordSlashProjectile : MonoBehaviour 
{
	void OnTriggerEnter(Collider _col)
	{
		ICanBeShot shot = _col.gameObject.GetComponent<ICanBeShot> ();
		if (shot != null) 
		{
			shot.HitMe ();
		}
		else
		{
			//Debug.Log ("hit nondestructible");	
		}
	}
}
