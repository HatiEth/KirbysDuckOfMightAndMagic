using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
public class RandomizeMesh : MonoBehaviour {

	public Mesh[] Meshs;
	public bool RandomizeOnStart = false;

	private MeshFilter meshFilter;

	// Use this for initialization
	void Start () {
		meshFilter = GetComponent<MeshFilter>();
		if (RandomizeOnStart) Randomize();
	}
	
	public void Randomize()
	{
		meshFilter.mesh = Meshs[Random.Range(0, Meshs.Length)];
	}
}
