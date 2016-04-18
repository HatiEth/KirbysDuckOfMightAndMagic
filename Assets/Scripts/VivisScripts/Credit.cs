using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Credit : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) {
            SceneManager.LoadScene(SceneManager.GetSceneByName("MainMenu").buildIndex);
        }
    }
}
