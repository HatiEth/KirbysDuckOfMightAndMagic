using UnityEngine;
using System.Collections;

public class IdleBehaviour : MonoBehaviour {

	Animator anim;
	public Quaternion moveAngle;

	Quaternion Angle;
	BreadMovement movement;


	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		movement = GetComponent<BreadMovement>();
		moveAngle = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
	}

	// Update is called once per frame
	void Update()
	{

		moveAngle = Angle * Quaternion.Euler(0f, Random.Range(0f, 270f), 0f);

		Angle = Quaternion.Slerp(Angle, moveAngle, Time.deltaTime);
	}

	public void OnDrawGizmos()
	{

		Gizmos.color = Color.yellow;
		Gizmos.matrix = Matrix4x4.identity;

		Gizmos.DrawLine(transform.position, transform.position + Angle * new Vector3(1, 0, 0));

	}

	void FixedUpdate()
	{
		Vector3 v = Angle * new Vector3(1, 0, 0);
		movement.Move(v.x, v.z);
	}
}
