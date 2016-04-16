using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public float LifetimeS = 0f;
	Rigidbody m_rigidThis;

	void Start()
	{
		m_rigidThis = GetComponent<Rigidbody> ();
		if(LifetimeS > 0f)
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
		float angle = Vector3.Angle (Vector3.forward, m_rigidThis.velocity);
		if (m_rigidThis.velocity.x < 0)
			angle = -angle;
		Quaternion qRotation = Quaternion.Euler (new Vector3 (30.0f, 0.0f, -angle));
		transform.localRotation = qRotation;
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
			//Debug.Log ("hit nondestructible");	
		}
	}
}
