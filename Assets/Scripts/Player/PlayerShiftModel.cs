using UnityEngine;
using System.Collections;

public class PlayerShiftModel : MonoBehaviour {

	public enum State {
		Default,
		Sword,
		Bow,
		Shield
	}

	public float ShiftDuration = 1f;
	public State ShiftState = State.Default;

}
