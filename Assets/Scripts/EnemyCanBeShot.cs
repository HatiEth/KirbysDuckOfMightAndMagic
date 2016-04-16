using UnityEngine;
using System.Collections;

public class EnemyCanBeShot : MonoBehaviour, ICanBeShot
{
	public virtual void HitMe(IProjectile projectile)
	{
		HealthResource hc = GetComponent<HealthResource>();
		if(hc != null)
		{
			hc.Take(projectile.Damage);
		}
		else
		{
			GameObject.Destroy (this.gameObject);
		}
	}
}
