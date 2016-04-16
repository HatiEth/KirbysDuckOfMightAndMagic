using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private string startText = "Starten";
    [SerializeField]
    private string creditsText = "Credits";
    [SerializeField]
    private string endText = "Beenden";
    [SerializeField]
    private float threshhold = 0.4f;

    private Text[] texts;
    private string[] strings;
    private int selector = 0;
    private bool hasSelected = false;

    void Awake()
    {
        texts = new Text[3];
        texts[0] = transform.GetChild(0).GetComponent<Text>();
        texts[1] = transform.GetChild(1).GetComponent<Text>();
        texts[2] = transform.GetChild(2).GetComponent<Text>();
        strings = new string[]{startText, creditsText, endText};
    }

    void Start()
    {
        texts[0].text = ">> " + startText + " <<";
    }

    void Update()
    {
        float v = Input.GetAxis("Vertical");
        Debug.Log("Vertical: " + v);

        if (Mathf.Abs(v) < threshhold)
            hasSelected = false;

        if (hasSelected)
            return;

        if (v > threshhold){
            texts[selector].text = strings[selector];
            if (selector == 0)
                selector = 2;
            else
                selector--;
        }
        else if (v < -threshhold){
            texts[selector].text = strings[selector];
            selector++;
        }
        else
            return;

        selector %= 3;
        hasSelected = true;
        texts[selector].text = ">> " + strings[selector] + " <<";

        if (Input.GetButtonDown("Fire") || Input.GetKeyDown(KeyCode.Return)) {
            switch (selector) {
                case 0: SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); break;
                case 1: SceneManager.LoadScene(SceneManager.GetSceneByName("Credits").buildIndex); break;
                case 2: Application.Quit(); break;
            }
        }
    }
}
