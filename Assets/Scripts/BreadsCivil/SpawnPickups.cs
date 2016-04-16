using UnityEngine;
using System.Collections;

public class SpawnPickups : MonoBehaviour {

	public GameObject Drop;

	public int Max = 3;
	public float DropChance = .10f;

	// Use this for initialization
	void Start () {
		GetComponent<HealthResource>().DeathCallback += () =>
		{
			int spawned = 0;
			for (int i=0;i<Max;++i)
			{
				if(Random.Range(0f, 1f) <= DropChance)
				{
					GameObject.Instantiate(Drop, transform.position, Quaternion.identity);
				}

			}
		};
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
