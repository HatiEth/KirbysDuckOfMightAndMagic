using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour 
{
	[SerializeField]
	private StaminaResource health; 

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
			text.text = "Stamina:" + health.Current;
		}
	}
}
