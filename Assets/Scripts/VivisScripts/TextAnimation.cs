using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TextAnimation : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float skipSpeed;
    [SerializeField]
    private float lerpSpeed;

    private float currSpeed = 0f;
    private Vector3 direction;
    new private Transform transform;

    void Awake()
    {
        transform = GetComponent<Transform>();
        direction = transform.up;
    }
    void Update()
    {
        // Skip
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return)) {
            // Load the next Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // Faster
        if (Input.GetKey(KeyCode.Space)) {
            currSpeed = Mathf.Lerp(currSpeed, skipSpeed, lerpSpeed * Time.deltaTime);
        }
        else {
            currSpeed = Mathf.Lerp(currSpeed, speed, lerpSpeed * Time.deltaTime);
        }

        transform.position = transform.position + direction * currSpeed * Time.deltaTime;
    }
}
