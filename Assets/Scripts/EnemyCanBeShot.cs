using UnityEngine;
using System.Collections;

public class EnemyCanBeShot : MonoBehaviour, ICanBeShot
{
	public virtual void HitMe()
	{
		GameObject.Destroy (this.gameObject);
	}
}
