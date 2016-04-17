using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour 
{
	[SerializeField]
	private HealthResource health; 

	private Text text;
	void Start()
	{
		text = GetComponent<Text> ();
	}
	// Update is called once per frame
	void Update () 
	{
		if (health)
		{
			text.text = "PlayerHealth:" + health.Current;
		}
	}
}
