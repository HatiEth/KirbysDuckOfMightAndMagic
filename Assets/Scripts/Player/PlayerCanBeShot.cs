using UnityEngine;
using System.Collections;

public class PlayerCanBeShot: MonoBehaviour, ICanBeShot
{
	public bool m_bBlocking = false;

	void Start()
	{
	}

	public virtual void HitMe(IProjectile projectile)
	{
		if (m_bBlocking)
		{
			return;
		}
		else
		{
			HealthResource hc = GetComponent<HealthResource>();
			hc.Take(projectile.Damage);
		}
	}
}
