using UnityEngine;
using System.Collections;

public class PlayerCanBeShot: MonoBehaviour, ICanBeShot
{
	public bool m_bBlocking = false;
	public virtual void HitMe()
	{
		if (!m_bBlocking)
			Debug.Log ("Ouchie! Player got hit!");
	}
}
