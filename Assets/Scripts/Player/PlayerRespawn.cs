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
		anim = GetComponentInChildren<Animator>();
		rigidbody = GetComponent<Rigidbody>();
		Health = GetComponent<HealthResource>();


		Health.DeathCallback += () => {
			StartCoroutine(Respawn());
		};
	}

	IEnumerator Respawn()
	{
		anim.SetTrigger("tRespawn");
		anim.SetLayerWeight(4, 1f);
		Health.Invulnerable = true;
		rigidbody.velocity = Vector3.zero;



		yield return new WaitForSeconds(fRespawnDelayS);
		anim.SetTrigger("tRespawn");
		Health.Heal(Health.Maximum);
		transform.position = lastCheckpoint.position;
		transform.rotation = Quaternion.identity;

		yield return new WaitForSeconds(fRespawnDelayS);
		anim.SetLayerWeight(4, 0f);
		Health.Invulnerable = false;
	}

	public void ActivateCheckpoint(Transform t)
	{
		lastCheckpoint = t;
	}
	
}
