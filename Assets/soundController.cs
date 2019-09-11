using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( AudioSource ) )]
public class soundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClick;
    [SerializeField]
    private AudioClip audioWin;
    [SerializeField]
    private AudioClip audioLose;

    private AudioSource audioS;

    private bool mute = false;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown( KeyCode.M ))
        {
            mute = !mute;

            Volume( mute );
        }
    }

    private void SetAudio(AudioClip clip)
    {
        audioS.clip = clip;

        audioS.Play();
    }

    public void PlayAudioClick()
    {
        SetAudio( audioClick );
    }

    public void PlayAudioWin()
    {
        SetAudio( audioWin );
    }

    public void PlayAudioLose()
    {
        SetAudio( audioLose );
    }

    public void Volume(bool vol)
    {
        audioS.mute = vol;
    }
}
