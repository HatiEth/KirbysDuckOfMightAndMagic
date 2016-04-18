using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WarningScreen : MonoBehaviour {

    [SerializeField]
    private float endTime = 5f;

    private float timer = 0f;

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer > endTime) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
}
