using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdjustFontSize : MonoBehaviour {

    [SerializeField]
    private int defaultSize = 10;
    [SerializeField]
    private float defaultWidth = 600;

    private Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Start()
    {
        Debug.Log("screenwidth = " + Screen.width);
        text.fontSize = Mathf.RoundToInt((float) defaultSize * (float) Screen.width / (defaultWidth * 1.0f));
    }
}
