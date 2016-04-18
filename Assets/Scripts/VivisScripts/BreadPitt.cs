﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BreadPitt : MonoBehaviour {

    [SerializeField]
    private string playerTag = "player";

    private bool triggered = false;
    private new AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (triggered)
            return;

        if (c.CompareTag(playerTag)) {
            DialogHandler.instance.StartDialog(Dialogs.bradPittDialog);
            triggered = true;
        }
    }

    // CALL THIS ON IgotHit
    public void Laugh()
    {
        if (audio.isPlaying)
            return;

        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.Play();
    }
}
