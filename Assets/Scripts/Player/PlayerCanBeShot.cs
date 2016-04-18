using UnityEngine;
using System.Collections;

public class PlayerCanBeShot: MonoBehaviour, ICanBeShot
{
	public bool m_bBlocking = false;
	private new AudioSource audio;

	void Awake()
	{
		audio = GetComponent<AudioSource> ();
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
			if (!audio.isPlaying)
				audio.Play ();
		}
	}
}
