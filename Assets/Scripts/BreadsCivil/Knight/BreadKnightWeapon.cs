using UnityEngine;
using System.Collections;

public class BreadKnightWeapon : ProjectileWeapon {

	[SerializeField]
	protected float BulletDeviation;

	[SerializeField]
	protected int Bullets;

	[SerializeField]
	protected float BulletDelay = 0.3f;

	public float AttackTimeS = 3f;
	private float AttackTimer;

	
	

	public Transform spawnAnchor;

	void Update()
	{
		AttackTimer = Mathf.Max(AttackTimer - Time.deltaTime, 0f);
	}

	public override bool Fire()
	{
		if (AttackTimer > 0f) return false;
		StartCoroutine(SpawnProjectiles());

		AttackTimer += Mathf.Max(BulletDelay * Bullets, AttackTimeS);

		return true;
	}

	protected IEnumerator SpawnProjectiles()
	{
		int i = 0;
		Vector3 forward = transform.forward;

		Quaternion q = Quaternion.Euler(0f, 0.5f * Bullets * BulletDeviation, 0f);

		for(;i<Bullets;++i)
		{

			GameObject proj = GameObject.Instantiate(m_goProjectilePrefab, transform.position + (q*q * forward) * 0.2f, Quaternion.identity) as GameObject;

			Rigidbody rb = proj.GetComponent<Rigidbody>();


			rb.AddForce(q * forward * m_fShotPower, ForceMode.Impulse);
			q *= Quaternion.Euler(0f, -BulletDeviation, 0f);

			yield return new WaitForSeconds(BulletDelay);
		}
	}
}
