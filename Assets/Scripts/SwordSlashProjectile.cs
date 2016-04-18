using UnityEngine;
using System.Collections;
using System;

public class SwordSlashProjectile : MonoBehaviour, IProjectile
{

	public int _Damage;
	public int Damage
	{
		get	{	return _Damage;	}
		set	{	_Damage = value;	}
	}
	System.Collections.Generic.List<ICanBeShot> hits = new System.Collections.Generic.List<ICanBeShot>();

	void OnTriggerEnter(Collider _col)
	{
		ICanBeShot shot = _col.gameObject.GetComponent<ICanBeShot> ();
		if (shot != null && !hits.Contains(shot)) 
		{
			hits.Add(shot);
			shot.HitMe (this);
		}
		else
		{
			//Debug.Log ("hit nondestructible");	
		}
	}
}
