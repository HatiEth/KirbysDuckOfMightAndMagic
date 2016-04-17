using UnityEngine;
using System.Collections;
using System;

public class ProjectileWeapon : MonoBehaviour
{
	[SerializeField]
	protected GameObject m_goProjectilePrefab;

	[SerializeField]
	public float StaminaUsage;

	protected Vector3 m_v3ShotDirectionOffset = new Vector3(0.0f, 0.0f, 0.0f);
	protected float m_fShotPower = 3.0f;
	protected float m_fDestroyDelay = 1.0f;
	protected Rigidbody m_rigidThis;

	// Use this for initialization
	protected virtual void Start () 
	{
		m_rigidThis = GetComponent<Rigidbody> ();
	}

	public virtual bool Fire()
	{
		GameObject goProjectile = GameObject.Instantiate (m_goProjectilePrefab, transform.position, transform.rotation) as GameObject;
		goProjectile.transform.parent = this.transform;
		Rigidbody rigidProjectile = goProjectile.GetComponent<Rigidbody> ();
		rigidProjectile.AddForce ((transform.forward + m_v3ShotDirectionOffset) * m_fShotPower, ForceMode.Impulse);
		StartCoroutine (DelayDestroyProjectile (goProjectile));
		return true;
	}

	protected IEnumerator DelayDestroyProjectile(GameObject _go)
	{
		yield return new WaitForSeconds (m_fDestroyDelay);
		GameObject.Destroy (_go);
	}

	protected void DestroyProjectile(GameObject _go)
	{
		GameObject.Destroy (_go);
	}
}
