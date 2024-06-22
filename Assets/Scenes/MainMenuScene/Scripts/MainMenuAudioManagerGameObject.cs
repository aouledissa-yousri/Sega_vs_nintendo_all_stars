using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class MainMenuAudioManagerGameObject : MonoBehaviour {
    [Header("---------Audio Source--------")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    [Header("---------Audio Clip--------")]
    public AudioClip background;
    public AudioClip buttonClick;
    public AudioClip buttonNavigate;

    private void Start() {
        StartBackgroundMusic();
    }

    private void Update() {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) ButtonNavigate();
    }

    public void ExitGame() {
        ButtonClick();
        Application.Quit();
    }

    public void GoToVSMode() {
        ButtonClick();
        SceneManager.LoadScene("CharacterSelectScene");
    }

    public void GoToTrainingMode() {
        ButtonClick();
        SceneManager.LoadScene("CharacterSelectScene");
    }

    private void ButtonClick() {
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


}
