using UnityEngine;
using System.Collections;

public class PlayerSwordAttack : ProjectileWeapon {
	private GameObject m_goActiveSlash;
	private Rigidbody m_rigidActiveSlash;
	public bool m_bIsSlashing { get; private set; }

	private float m_fSlashTimer = 0.05f;
	private float m_fSlashWidth = 1.0f;
	private int m_iNumSlashSteps = 3;
	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		m_fShotPower = 0.0f;
		m_fDestroyDelay = 0.2f;
	}

	public override bool Fire()
	{
		Debug.Log("Slash Attack");
		m_goActiveSlash = GameObject.Instantiate(m_goProjectilePrefab, transform.position, transform.rotation) as GameObject;
		m_rigidActiveSlash = m_goActiveSlash.GetComponent<Rigidbody>();
		m_bIsSlashing = true;
		StartCoroutine(SlashAttack());
		return true;
	}

	private IEnumerator SlashAttack()
	{
		Vector3 v3SlashStep = transform.localToWorldMatrix * new Vector3(m_fSlashWidth / m_iNumSlashSteps, 0.0f, 0.0f);
		for (int i = 0; i < m_iNumSlashSteps; ++i)
		{
			m_rigidActiveSlash.MovePosition(transform.position - ((-m_iNumSlashSteps / 2 + i) * v3SlashStep));
			yield return new WaitForSeconds(m_fSlashTimer);
		}

		DestroyProjectile(m_goActiveSlash);

		m_goActiveSlash = null;
		m_rigidActiveSlash = null;
		m_bIsSlashing = false;
	}

}
