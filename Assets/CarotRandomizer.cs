using UnityEngine;
using System.Collections;

public class CarotRandomizer : MonoBehaviour 
{
	[SerializeField]
	Sprite[] m_sprites;
	SpriteRenderer m_spriterenderThis;
	
	void Start()
	{
		m_spriterenderThis = GetComponent<SpriteRenderer> ();
		int i = Random.Range (0, m_sprites.Length - 1);
		m_spriterenderThis.sprite = m_sprites [i];
	}
}
