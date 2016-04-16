using UnityEngine;
using System.Collections;

public class ProjectileWeapon : MonoBehaviour 
{
	[SerializeField]
	private GameObject m_goProjectilePrefab;

	private Vector3 m_v3ShotDirectionOffset = new Vector3(0.0f, 0.0f, 0.0f);
	private float m_fShotPower = 3.0f;
	private float m_fLifeTime = 1.0f;
	private Rigidbody m_rigidThis;

	// Use this for initialization
	void Start () 
	{
		m_rigidThis = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Fire()
	{
		GameObject goProjectile = GameObject.Instantiate (m_goProjectilePrefab, transform.position, transform.rotation) as GameObject;
		Rigidbody rigidProjectile = goProjectile.GetComponent<Rigidbody> ();
		rigidProjectile.AddForce ((transform.forward + m_v3ShotDirectionOffset) * m_fShotPower, ForceMode.Impulse);
		StartCoroutine (KillProjectile (goProjectile));
	}

	private IEnumerator KillProjectile(GameObject _go)
	{
		yield return new WaitForSeconds (m_fLifeTime);
		GameObject.Destroy (_go);
	}
}
