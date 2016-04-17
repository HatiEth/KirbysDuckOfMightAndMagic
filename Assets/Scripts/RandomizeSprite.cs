using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomizeSprite : MonoBehaviour {

	private SpriteRenderer sprite;
	public Sprite[] sprites;
	public bool RandomizeOnStart = false;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		if (RandomizeOnStart) Randomize();
	
	}
	
	public void Randomize()
	{
		sprite.sprite = sprites[Random.Range(0, sprites.Length)];
	}
}
