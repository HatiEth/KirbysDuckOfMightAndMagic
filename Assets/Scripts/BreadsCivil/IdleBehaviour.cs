using UnityEngine;
using System.Collections;

public class IdleBehaviour : MonoBehaviour {

	private NavMeshAgent agent;
	public Transform ScaredFrom = null;
	public Quaternion moveAngle;

	Quaternion Angle;
	BreadMovement movement;


	// Use this for initialization
	void Start()
	{
		movement = GetComponent<BreadMovement>();
		moveAngle = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updatePosition = false;
	}

	// Update is called once per frame
	void Update()
	{
		if(!ScaredFrom)
		{
			moveAngle = Angle * Quaternion.Euler(0f, Random.Range(0f, 270f), 0f);

			Angle = Quaternion.Slerp(Angle, moveAngle, Time.deltaTime);


			Vector3 v = Angle * new Vector3(1, 0, 0);
			agent.SetDestination(transform.position + v);
		}
		else
		{
			agent.SetDestination(transform.position + (ScaredFrom.position - transform.position).normalized);
		}

	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		Gizmos.DrawLine(transform.position, transform.position + Angle * new Vector3(1, 0, 0));
	}

	void FixedUpdate()
	{
		Vector3 v = agent.desiredVelocity * Time.deltaTime;
		Debug.Log(v);
		movement.Move(v.x, v.z);
	}

	public void Scare(Transform t)
	{
		ScaredFrom = t;
	}
}
