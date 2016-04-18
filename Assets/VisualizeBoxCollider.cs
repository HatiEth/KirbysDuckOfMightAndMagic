using UnityEngine;
using System.Collections;

public class VisualizeBoxCollider : MonoBehaviour {
	#if UNITY_EDITOR
	void OnDrawGizmos()
	{
		Vector3 pos = transform.position + GetComponent<BoxCollider> ().center;
		Gizmos.color = Color.red;
		Gizmos.DrawCube (pos, GetComponent<BoxCollider> ().size * transform.lossyScale.x);
	}
	#endif
}
