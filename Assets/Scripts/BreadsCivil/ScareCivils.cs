using UnityEngine;
using System.Collections;

public class ScareCivils : MonoBehaviour 
{

	public float ScareTimeoutS = 3f;
	private new Transform transform;

	void Start()
	{
		transform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{
		ScareTimeoutS -= Time.deltaTime;
		if (ScareTimeoutS < 0)
		{
			Destroy(gameObject);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		var scareable = other.GetComponent<IScareable>();
		if(scareable != null)
		{
			scareable.Scare(transform);
		}
	}
}
