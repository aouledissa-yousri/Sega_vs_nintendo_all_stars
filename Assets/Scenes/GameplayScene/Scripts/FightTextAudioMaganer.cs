using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTextAudioManager : MonoBehaviour {

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    public void PlayReadyFightSound() {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    
}
