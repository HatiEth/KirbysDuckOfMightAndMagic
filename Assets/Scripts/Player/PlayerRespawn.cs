using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HealthResource))]
public class PlayerRespawn : MonoBehaviour {
	private HealthResource Health;

	[SerializeField]
	private Transform lastCheckpoint;

	private new Rigidbody rigidbody;

	public float fRespawnDelayS = 1f;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody>();
		Health = GetComponent<HealthResource>();
		Health.DeathCallback += () => {
			Debug.Log("Respawn");
			StartCoroutine(Respawn());
		};
	}

	IEnumerator Respawn()
	{
		anim.SetTrigger("tRespawn");
		GetComponentInChildren<SpriteRenderer>().enabled = false;
		rigidbody.velocity = Vector3.zero;
		yield return new WaitForSeconds(fRespawnDelayS);
		rigidbody.velocity = Vector3.zero;
		GetComponentInChildren<SpriteRenderer>().enabled = true;
		transform.position = lastCheckpoint.position;
		Health.Heal(Health.Maximum);
	}

	public void ActivateCheckpoint(Transform t)
	{
		lastCheckpoint = t;
	}
	
}
