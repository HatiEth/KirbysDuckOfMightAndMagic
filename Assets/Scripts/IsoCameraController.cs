using UnityEngine;
using System.Collections;

public class IsoCameraController : MonoBehaviour 
{
	[SerializeField]
	Vector3 m_v3CameraToPlayerOffset = new Vector3(0.0f, 4.0f, -4.85f);
	[SerializeField]
	float m_fCameraSpeed = 2.0f;
	[SerializeField]
	float m_fVelocityWeigth = 3.0f;
	Rigidbody m_rigidPlayer;

	Vector3 m_v3MovementDirection;
	// Use this for initialization
	void Start () 
	{
		m_rigidPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 v3desiredPosition = (m_rigidPlayer.position + m_v3MovementDirection * m_fVelocityWeigth) + m_v3CameraToPlayerOffset;
		transform.position = Vector3.Lerp(transform.position, v3desiredPosition, Time.deltaTime * m_fCameraSpeed);
		Debug.DrawLine (m_rigidPlayer.position, m_rigidPlayer.position + m_v3MovementDirection * m_fVelocityWeigth, Color.green);
		Debug.Log (m_rigidPlayer.velocity);
	}

	public void SetDirection(Vector3 _v3)
	{
		m_v3MovementDirection = _v3;
	}
}
