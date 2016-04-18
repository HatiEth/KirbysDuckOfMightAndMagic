using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaFillView : MonoBehaviour {

	public StaminaResource Stamina;
	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		image.fillAmount = Stamina.Current / Stamina.Max;
	}
}
