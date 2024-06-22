using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonSelectSoundEffect;

    public void PlayButtonSelectSoundEffect() {
        audioSource.clip = buttonSelectSoundEffect;
        audioSource.Play();
    }
}
