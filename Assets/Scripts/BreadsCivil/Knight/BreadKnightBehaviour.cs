using UnityEngine;
using System.Collections;
using System;

using Random = UnityEngine.Random;

public class BreadKnightBehaviour : MonoBehaviour, IScareable {

	public bool Alarmed = false;

	private NavMeshAgent Agent;
	private Transform Player;

	BreadKnightMovement movement;

	Vector3 TargetPosition;
	public float TargetAcquisition = 0.1f;
	public float AttackChance = 0.33f;

	public Quaternion moveAngle;

	Quaternion Angle;
	// Use this for initialization
	void Start()
	{
		Angle = Quaternion.identity;
		moveAngle = Quaternion.identity;

		Player = GameObject.FindGameObjectWithTag("Player").transform;
		Agent = GetComponent<NavMeshAgent>();
		movement = GetComponent<BreadKnightMovement>();

		Agent.updateRotation = false;
	}

	void Update()
	{
		if (Alarmed)
		{
			if (Player == null) return;


			Agent.SetDestination(Player.position);

			if (Agent.remainingDistance > Agent.stoppingDistance)
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

					if (Random.Range(0f, 1f) <= AttackChance)
					{
						movement.Attack((TargetPosition - transform.position).normalized);
					}
				}
			}

		}
		else
		{
			moveAngle = Angle * Quaternion.Euler(0f, Random.Range(-70f, 70f), 0f);
			Angle = Quaternion.Slerp(Angle, moveAngle, Time.deltaTime*5f);
			Vector3 v = Angle * Vector3.right;

			Agent.SetDestination(transform.position + v);

			if (Agent.remainingDistance > Agent.stoppingDistance)
			{
				movement.Move(Agent.desiredVelocity.x, Agent.desiredVelocity.z);
			}
			else
			{
				movement.Move(0f, 0f);

				Angle = Quaternion.Euler(0f, 180f, 0f) * Angle;
			}
		}
	}

	public void OnDrawGizmos()
	{

		Gizmos.color = Color.red;

		if (Agent != null)
		{
			if(Alarmed)
			{
				Gizmos.DrawLine(transform.position, transform.position + Agent.desiredVelocity.normalized * 0.3f);
			}
			else
			{
				Gizmos.DrawLine(transform.position, transform.position + Agent.desiredVelocity.normalized * 0.3f);
			}


			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(transform.position, TargetPosition);
		}

	}

	public void Scare(Transform t)
	{
		Alarmed = true;

		StartCoroutine(AlarmAway());
	}

	IEnumerator AlarmAway()
	{
		yield return new WaitForSeconds(3f);
		Alarmed = false;
	}
}
