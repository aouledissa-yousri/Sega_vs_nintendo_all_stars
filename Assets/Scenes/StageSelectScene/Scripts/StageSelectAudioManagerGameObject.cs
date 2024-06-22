using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectAudioManagerGameObject : MonoBehaviour {

    [Header("---------Audio Source--------")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    [Header("---------Audio Clip--------")]
    public AudioClip background;
    public AudioClip buttonClick;
    public AudioClip buttonNavigate;
    public AudioClip cancel;

    private void Start() {
        StartBackgroundMusic();
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
   
}
