using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroDialogLevel : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem magicSpell;
    [SerializeField]
    private AudioClip magicClip;

    private bool started = false;
    private bool magicStarted = false;
    private bool secondStarted = false;
    private AudioSource _audio;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!started) {
            DialogHandler.instance.StartDialog(Dialogs.firstDialogDuckAndKirby);
            started = true;
        }

        else if (started && !DialogHandler.IN_DIALOG && !magicStarted) {
            DoMagic();
            magicStarted = true;
        }

        else if (magicStarted && !magicSpell.isPlaying && !secondStarted) {
            secondStarted = true;
            DialogHandler.instance.StartDialog(Dialogs.secondDialogDuckAndKirby);
        }

        else if (secondStarted && !DialogHandler.IN_DIALOG) {
            Debug.Log("Next Level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void DoMagic()
    {
        magicSpell.Play();
        _audio.PlayOneShot(magicClip);
    }
}
