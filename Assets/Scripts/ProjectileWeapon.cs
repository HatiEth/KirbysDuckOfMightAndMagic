using UnityEngine;
using System.Collections;

public class ProjectileWeapon : MonoBehaviour 
{
	[SerializeField]
	protected GameObject m_goProjectilePrefab;

	protected Vector3 m_v3ShotDirectionOffset = new Vector3(0.0f, 0.0f, 0.0f);
	protected float m_fShotPower = 3.0f;
	protected float m_fDestroyDelay = 1.0f;
	protected Rigidbody m_rigidThis;

	// Use this for initialization
	protected virtual void Start () 
	{
		m_rigidThis = GetComponent<Rigidbody> ();
	}

	public virtual void Fire()
	{
		GameObject goProjectile = GameObject.Instantiate (m_goProjectilePrefab, transform.position, transform.rotation) as GameObject;
		goProjectile.transform.parent = this.transform;
		Rigidbody rigidProjectile = goProjectile.GetComponent<Rigidbody> ();
		rigidProjectile.AddForce ((transform.forward + m_v3ShotDirectionOffset) * m_fShotPower, ForceMode.Impulse);
		StartCoroutine (DestroyProjectile (goProjectile));
	}

	protected IEnumerator DestroyProjectile(GameObject _go)
	{
		yield return new WaitForSeconds (m_fDestroyDelay);
		GameObject.Destroy (_go);
	}
}
