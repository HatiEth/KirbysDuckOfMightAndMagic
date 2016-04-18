using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthUIView : MonoBehaviour {

	public HealthResource HealthData;
	public int HealthMin;
	public Sprite[] Sprites;
	private Image image;

	void Start()
	{
		image = GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {
		if (!HealthData) return;
		if(HealthData.Current < HealthMin)
		{
			image.sprite = Sprites[0];
		}
		else
		{
			var d = HealthData.Current - HealthMin;

			image.sprite = Sprites[1+Mathf.Min(Sprites.Length - 2, d)];
		}
	
	}
}
