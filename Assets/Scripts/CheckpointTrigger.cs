using UnityEngine;
using System.Collections;

public class CheckpointTrigger : MonoBehaviour {
	public void OnTriggerEnter(Collider other)
	{
		var respawn = other.GetComponent<PlayerRespawn>();
		if(respawn)
		{
			respawn.ActivateCheckpoint(this.transform);

			this.enabled = false;
			Debug.Log("Activated Checkpoint at " + transform.position);
		}
	}
}
