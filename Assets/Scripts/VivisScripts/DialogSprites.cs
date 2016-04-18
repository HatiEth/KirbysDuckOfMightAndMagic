using UnityEngine;
using System.Collections;

public class DialogSprites : MonoBehaviour {

    public static DialogSprites instance = null;  

    public static string duckString = "duck";
    public static string sorcererString = "sorcerer";
    public static string breadString = "bread";
    public static string bradString = "brad";

    public Sprite duckSprite;
    public Sprite sorcererSprite;
    public Sprite breadSprite;
    public Sprite bradSprite;
    public AudioClip duckClip;
    public AudioClip sorcererClip;
    public AudioClip breadClip;
    public AudioClip bradClip;

    void Awake()
    {
        // singleton
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void getStuff(string s, out Sprite sprite, out DialogAudio audio)
    {
        switch (s) {
            case "duck":
                sprite = duckSprite;
                audio = new DialogAudio(duckClip, 0.7f, 1.3f); 
                break;
            case "sorcerer":
                sprite = sorcererSprite;
                audio = new DialogAudio(sorcererClip, 0.4f, 0.6f);
                break;
            case "bread":
                sprite = breadSprite;
                audio = new DialogAudio(breadClip, 0.4f, 0.9f);
                break;
            case "brad":
                sprite = bradSprite;
                audio = new DialogAudio(bradClip, 0.8f, 1.2f);
                break;
            default:
                sprite = duckSprite;
                audio = new DialogAudio(duckClip, 1f, 1f);
                break;
        }
    }
}

public class DialogAudio
{
    public AudioClip m_soundClip;
    public float m_fMinPitch;
    public float m_fMaxPitch;

    public DialogAudio(AudioClip clip, float minPitch, float maxPitch)
    {
        m_soundClip = clip;
        m_fMinPitch = minPitch;
        m_fMaxPitch = maxPitch;
    }
}