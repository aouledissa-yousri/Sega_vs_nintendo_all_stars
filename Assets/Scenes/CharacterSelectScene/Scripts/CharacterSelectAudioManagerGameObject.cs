using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelectAudioManagerGameObject : MonoBehaviour {
    [Header("---------Audio Source--------")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource characterSfx;

    [Header("---------Audio Clip--------")]
    public AudioClip background;
    public AudioClip buttonClick;
    public AudioClip buttonNavigate;
    public AudioClip cancel;
    public AudioClip characterSelect;

    private void Start() {
        StartBackgroundMusic();
        SelectCharacter();
    }

    private void Update() {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) ButtonNavigate();
        if(Input.GetKeyDown(KeyCode.C)) Cancel();
    }

    public void ButtonClick() {
        sfx.clip = buttonClick;
        sfx.Play();
    }

    private void StartBackgroundMusic() {
        music.clip = background;
        music.Play();
    }

    private void ButtonNavigate(){
        sfx.clip = buttonNavigate;
        sfx.Play();
    }

    public void Cancel(){
        sfx.clip = cancel;
        sfx.Play();
    }

    public void SelectCharacter() {
        sfx.clip = characterSelect;
        sfx.Play();
    }

    public void PlayCharacterSound(AudioClip characterSound) {
        characterSfx.clip = characterSound;
        characterSfx.Play(); 
    }


}
