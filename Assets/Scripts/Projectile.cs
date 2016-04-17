using UnityEngine;
using System.Collections;
using System;

public class Projectile : MonoBehaviour, IProjectile {
	public int _Damage = 0;
	public float LifetimeS = 0f;
	Rigidbody m_rigidThis;

	public int Damage
	{
		get	{	return _Damage;	}
		set	{	_Damage = value; }
	}

	void Start()
	{
		m_rigidThis = GetComponent<Rigidbody>();
		if (LifetimeS > 0f)
		{
			StartCoroutine(HandleLifetime());
		}
	}

	IEnumerator HandleLifetime()
	{
		yield return new WaitForSeconds(LifetimeS);
		Destroy(gameObject);
	}

	void Update()
	{
		if (m_rigidThis.velocity.magnitude > 0)
		{
			float angle = Vector3.Angle (Vector3.forward, m_rigidThis.velocity);
			if (m_rigidThis.velocity.x < 0)
				angle = -angle;
			Quaternion qRotation = Quaternion.Euler (new Vector3 (30.0f, 0.0f, -angle));
			transform.localRotation = qRotation;
		}
	}

	void OnCollisionEnter(Collision _col)
	{
		ICanBeShot shot = _col.gameObject.GetComponent<ICanBeShot>();
		if (shot != null)
		{
			shot.HitMe(this);
			m_rigidThis.isKinematic = true;
			m_rigidThis.velocity = Vector3.zero;
			GameObject.Destroy(this.gameObject);
		}
		else
		{
			//Debug.Log ("hit nondestructible");	
		}
	}

	void OnTriggerEnter(Collider other)
	{
		ICanBeShot shot = other.gameObject.GetComponent<ICanBeShot>();
		if (shot != null)
		{
			shot.HitMe(this);
			m_rigidThis.isKinematic = true;
			m_rigidThis.velocity = Vector3.zero;
			GameObject.Destroy(this.gameObject);
		}
		else
		{
			//Debug.Log ("hit nondestructible");	
		}

	}
}
