using UnityEngine;
using System.Collections;

public class BreadKnightWeapon : ProjectileWeapon {

	[SerializeField]
	protected float BulletDeviation;

	[SerializeField]
	protected int Bullets;

	[SerializeField]
	protected float BulletDelay = 0.3f;

	public Transform spawnAnchor;

	// Use this for initialization
	protected override void Start () {
	
	}

	
	public override void Fire()
	{
		StartCoroutine(SpawnProjectiles());
	}

	protected IEnumerator SpawnProjectiles()
	{
		int i = 0;
		Vector3 forward = spawnAnchor.forward;

		Quaternion q = Quaternion.Euler(0f, 0.5f * Bullets * BulletDeviation, 0f);

		for(;i<Bullets;++i)
		{

			GameObject proj = GameObject.Instantiate(m_goProjectilePrefab, transform.position + (q*q * forward) * 0.2f, Quaternion.identity) as GameObject;

			proj.transform.parent = transform;

			Rigidbody rb = proj.GetComponent<Rigidbody>();


			rb.AddForce(q * forward * m_fShotPower, ForceMode.Impulse);
			q *= Quaternion.Euler(0f, -BulletDeviation, 0f);

			yield return new WaitForSeconds(BulletDelay);
		}
	}
}
