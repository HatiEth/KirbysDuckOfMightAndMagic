using UnityEngine;
using System.Collections;

public class BreadKnightBehaviour : MonoBehaviour {

	public bool Alarmed = false;

	private NavMeshAgent Agent;
	private Transform Player;

	Vector3 TargetPosition;

	BreadKnightMovement movement;

	// Use this for initialization
	void Start()
	{

		Player = GameObject.FindGameObjectWithTag("Player").transform;
		Agent = GetComponent<NavMeshAgent>();
		movement = GetComponent<BreadKnightMovement>();

		Agent.updateRotation = false;

		TargetPosition = Player.position;

	}

	void Update()
	{
		/*
		float alpha = Random.Range(0f, 360f);
		Vector3 onCircle = new Vector3(Mathf.Cos(alpha), 0.0f, Mathf.Sin(alpha));
		*/
		Vector3 onCircle = Vector3.zero;

		//TargetPosition = Vector3.Slerp(TargetPosition, Player.position + onCircle * 0.1f, Time.deltaTime);
		TargetPosition = Player.position;

		Agent.SetDestination(TargetPosition);

		if(Agent.remainingDistance > Agent.stoppingDistance)
		{
			Vector3 v = Agent.desiredVelocity.normalized;
			movement.Move(v.x, v.z);
		}
		else
		{
			movement.Move(0f, 0f);

			if(Vector3.Distance(transform.position, Player.position) < 0.5f)
			{
				movement.Attack((TargetPosition - transform.position).normalized);
			}
		}

	}

	public void OnDrawGizmos()
	{

		Gizmos.color = Color.red;

		if(Agent != null)
		{
			Gizmos.DrawLine(transform.position, transform.position + Agent.desiredVelocity.normalized * 0.3f);
		}

	}
}
