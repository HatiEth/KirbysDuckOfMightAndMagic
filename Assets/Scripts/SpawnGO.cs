using UnityEngine;
using System.Collections;

public class SpawnGO : MonoBehaviour {
	public GameObject[] Drops;

	public int Max = 3;
	public float DropChance = .10f;

	// Use this for initialization
	void Start () {
		GetComponent<HealthResource>().DeathCallback += () =>
		{
			for (int i=0;i<Max;++i)
			{
				if(Random.Range(0f, 1f) <= DropChance)
				{
					var go = (GameObject)Instantiate(Drops[Random.Range(0, Drops.Length)], transform.position, Quaternion.identity);
				}
			}
		};
	}
}
