using UnityEngine;
using System.Collections;

public class BreadKnightBehaviour : MonoBehaviour {

	public bool Alarmed = false;

	private NavMeshAgent Agent;
	private Transform Player;

	BreadKnightMovement movement;

	Vector3 TargetPosition;
	public float TargetAcquisition = 0.1f;
	public float AttackChance = 0.33f;

	// Use this for initialization
	void Start()
	{

		Player = GameObject.FindGameObjectWithTag("Player").transform;
		Agent = GetComponent<NavMeshAgent>();
		movement = GetComponent<BreadKnightMovement>();

		Agent.updateRotation = false;


	}

	void Update()
	{
		if (Player == null) return;


		Agent.SetDestination(Player.position);

		if(Agent.remainingDistance > Agent.stoppingDistance)
		{
			Vector3 v = Agent.desiredVelocity.normalized;
			movement.Move(v.x, v.z);
			TargetPosition = Vector3.Lerp(TargetPosition, Player.position, TargetAcquisition);
		}
		else
		{
			movement.Move(0f, 0f);

			TargetPosition = Vector3.Lerp(TargetPosition, Player.position, TargetAcquisition);

			if (Vector3.Distance(transform.position, Player.position) < 0.7f)
			{

				if(Random.Range(0f, 1f) <= AttackChance)
				{
					movement.Attack((TargetPosition - transform.position).normalized);
				}
			}
		}

	}

	public void OnDrawGizmos()
	{

		Gizmos.color = Color.red;

		if(Agent != null)
		{
			Gizmos.DrawLine(transform.position, transform.position + Agent.desiredVelocity.normalized * 0.3f);


			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(transform.position, TargetPosition);
		}

	}
}
