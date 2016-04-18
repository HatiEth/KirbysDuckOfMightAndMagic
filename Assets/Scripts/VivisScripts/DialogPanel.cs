using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DialogPanel : MonoBehaviour {

    public static DialogPanel s_instance = null;  

    [SerializeField]
    private string m_stringMessage;
    [SerializeField]
    private float m_fLetterPause = 0.05f;
    [SerializeField]
    private AudioClip m_clipDuck;

    private DialogAudio m_audioCurrent;
    private AudioSource m_audioThis;
    private Text m_textThis;
    private bool m_bIsTyping = false;
    private Image m_imgThis;

    void Awake()
    {
        // singleton
        if (s_instance == null)
            s_instance = this;
        else if (s_instance != this)
            Destroy(gameObject);

        m_textThis = transform.GetComponentInChildren<Text>();
        Assert.IsNotNull<Text>(m_textThis);
        m_audioThis = GetComponent<AudioSource>();
        Assert.IsNotNull<AudioSource>(m_audioThis);
        m_imgThis = GetComponent<Image>();
        Assert.IsNotNull<Image>(m_imgThis);
    }

    void Start()
    {
        ShowPanel(false);
    }
	
	// Update is called once per frame
	void Update () {
        // Debug Test
        //if (Input.GetKeyDown(KeyCode.A) && !m_bIsTyping) {
        //    StartTalk(m_audioDuck);
        //}

        //// Press Space
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    Skip();
        //}
	}

    /* Returns false if just the text gets skipped
     * Returns true if the text is done and the next one can appear
     */
    public bool Skip()
    {
        // Skip Text
        if (m_bIsTyping) {
            StopAllCoroutines();
            string s = m_stringMessage.Replace("\\", "\n");
            m_textThis.text = s;
            m_bIsTyping = false;
            return false;
        }
        else
            return true;
    }

    public void StartTalk(DialogAudio who, Sprite sprite, string msg)
    {
        if (m_bIsTyping)
            return;

        setImage(sprite);
        m_stringMessage = msg;
        ShowPanel(true);
        m_audioCurrent = who;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        m_textThis.text = "";
        m_bIsTyping = true;
        bool newWord = true;
        
        foreach (char letter in m_stringMessage.ToCharArray()) {
            if (!letter.Equals('\\')){
                // Print one Character
                m_textThis.text += letter;
                // play sound! if its a new word
                if (newWord) {
                    RandomPitch(m_audioCurrent);
                    m_audioThis.PlayOneShot(m_audioCurrent.m_soundClip);
                    newWord = false;
                }

                if (letter.Equals(' '))
                    newWord = true;
            }
            else
                m_textThis.text += "\n";

            yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(m_fLetterPause));
        }
        m_bIsTyping = false;
    }

    void RandomPitch(DialogAudio audio)
    {
        float pitch = Random.RandomRange(audio.m_fMinPitch, audio.m_fMaxPitch);
        m_audioThis.pitch = pitch;
    }

    public void ShowPanel(bool b)
    {
        //(de)activate the image
        if (b)
            m_imgThis.color = Color.black;
        else
            m_imgThis.color = Color.clear;

        // (de)activate all the children
        for (int i = 0; i < transform.childCount; ++i) {
            transform.GetChild(i).gameObject.SetActive(b);
        }
    }

    public void setImage(Sprite sprite)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;
    }

    public bool isTyping()
    {
        return m_bIsTyping;
    }
}