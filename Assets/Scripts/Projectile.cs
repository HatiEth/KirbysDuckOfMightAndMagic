using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	Rigidbody m_rigidThis;

	void Start()
	{
		m_rigidThis = GetComponent<Rigidbody> ();
	}

	void OnCollisionEnter(Collision _col)
	{
		ICanBeShot shot = _col.gameObject.GetComponent<ICanBeShot> ();
		if (shot != null) 
		{
			shot.HitMe ();
			m_rigidThis.isKinematic = true;
			m_rigidThis.velocity = Vector3.zero;
			GameObject.Destroy (this.gameObject);
		}
		else
		{
			Debug.Log ("hit nondestructible");	
		}
	}
}
